using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query;
using Hahn.ApplicatonProcess.December2020.Data.Database;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Hahn.ApplicatonProcess.December2020.Web.Filters;
using Hahn.ApplicatonProcess.December2020.Web.Localization;
using Hahn.ApplicatonProcess.December2020.Web.Middleware;
using Hahn.ApplicatonProcess.December2020.Web.Models.v1;
using Hahn.ApplicatonProcess.December2020.Web.Validators.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hahn.ApplicatonProcess.December2020.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Configure the in memory database with application DB context. Get the Database name from the connection string.
            services.AddDbContext<ApplicantDbContext>(options => options.UseInMemoryDatabase(Configuration.GetConnectionString("DatabaseName")));
            // Configure the auto mapper with the type of startup file.
            services.AddAutoMapper(typeof(Startup));
            // Allow the cors for cross origin request.
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().
                            AllowAnyMethod().
                            AllowAnyHeader();

                        //builder.WithOrigins("http://localhost:8090", "http://localhost");
                    });
            });
            // Add the fluent validation on the models
            services.AddMvc().AddFluentValidation();

            // Configure the swagger for API's documentation
            services.AddSwaggerGen(options =>
            {
                options.SchemaFilter<ApplicantFilter>(); // Inject the applicant filter to assign the default values of specific model
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Hahn Application services",
                    Version = "v1",
                    Description = "Applicant service"
                });
            });

            #region Localization
            services.AddSingleton<IdentityLocalizationService>(); 
            services.AddLocalization(o =>
            {
                // We will put our translations in a folder called Resources
                o.ResourcesPath = "Resources";
            });
            // Resolve the dependency for json string localizer factory
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            // Resolve the dependency for json string localizer
            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>();
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                    opts => { opts.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization(options =>
                {
                });

            CultureInfo.CurrentCulture = new CultureInfo(Configuration.GetValue<string>("CurrentCulture")); // Define the current culture
            #endregion
            // Inject the MediatR to resolve the dependencies.
            services.AddMediatR(Assembly.GetExecutingAssembly());
            // Resolve the dependency for repository
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            // Resolve the dependency for validator of create applicant model
            services.AddTransient<IValidator<CreateApplicantModel>, CreateApplicantModelValidator>();
            // Resolve the dependency for validator of update applicant model
            services.AddTransient<IValidator<UpdateApplicantModel>, UpdateApplicantModelValidator>();
            // Resolve the dependency of create applicant command
            services.AddTransient<IRequestHandler<CreateApplicantCommand, Applicant>, CreateApplicantCommandHandler>();
            // Resolve the dependency of update applicant command
            services.AddTransient<IRequestHandler<UpdateApplicantCommand, Applicant>, UpdateApplicantCommandHandler>();
            // Resolve the dependency of delete applicant command
            services.AddTransient<IRequestHandler<DeleteApplicantCommand, bool>, DeleteApplicantCommandHandler>();
            // Resolve the dependency of get applicant query
            services.AddTransient<IRequestHandler<GetApplicantByIdQuery, Applicant>, GetApplicantByIdQueryHandler>();
            // Resolve the dependency of get all applicant query
            services.AddTransient<IRequestHandler<GetAllApplicantsQuery, List<Applicant>>, GetAllApplicantsHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            // get the current directory to store the logs
            var path = Directory.GetCurrentDirectory();
            // get the file name from configuration file
            loggerFactory.AddFile($"{path}\\Logs\\{Configuration.GetValue<string>("LogFileName")}"); 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // use the swagger middleware
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn Services"));
            // include the routing middleware
            app.UseRouting();
            // include the cors middleware
            app.UseCors();
            // include the authentication middleware
            app.UseAuthorization();
            // use for routing end points
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Add our new middleware to the pipeline
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            // Add the middleware the handle the exception at global level
            app.UseGlobalExceptionMiddleware();

            #region Localization
            // define the supported cultures
            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("de-DE")
            };
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: Configuration.GetValue<string>("DefaultCulture"), uiCulture: Configuration.GetValue<string>("DefaultCulture")),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
        
           // app.UseRequestLocalization(localizationOptions);

            var requestProvider = new RouteDataRequestCultureProvider();
            localizationOptions.RequestCultureProviders.Insert(0, requestProvider);
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            // use the localization middleware
            app.UseRequestLocalization(locOptions.Value);

            #endregion
        }
    }
}
