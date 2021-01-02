using System;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hahn.ApplicatonProcess.December2020.Web.Filters
{
    public class ApplicantFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = GetExampleOrNullFor(context.Type);
        }

        private IOpenApiAny GetExampleOrNullFor(Type type)
        {
            return type.Name switch
            {
                "CreateApplicantModel" => new OpenApiObject
                {
                    ["id"] = new OpenApiInteger(1),
                    ["Name"] = new OpenApiString("Ahsan"),
                    ["FamilyName"] = new OpenApiString("Raza"),
                    ["Address"] = new OpenApiString("Intagleo Systems"),
                    ["CountryOfOrigin"] = new OpenApiString("Pakistan"),
                    ["EmailAddress"] = new OpenApiString("ahsan.raza@intagleo.com"),
                    ["Age"] = new OpenApiInteger(27),
                    ["Hired"] = new OpenApiBoolean(true)
                },
                "UpdateApplicantModel" => new OpenApiObject
                {
                    ["id"] = new OpenApiInteger(1),
                    ["Name"] = new OpenApiString("Ahsan"),
                    ["FamilyName"] = new OpenApiString("Raza"),
                    ["Address"] = new OpenApiString("Intagleo Systems, Lahore"),
                    ["CountryOfOrigin"] = new OpenApiString("Pakistan"),
                    ["EmailAddress"] = new OpenApiString("ahsan.raza@intagleo.com"),
                    ["Age"] = new OpenApiInteger(27),
                    ["Hired"] = new OpenApiBoolean(true)
                },
                _ => null
            };
        }
    }
}
