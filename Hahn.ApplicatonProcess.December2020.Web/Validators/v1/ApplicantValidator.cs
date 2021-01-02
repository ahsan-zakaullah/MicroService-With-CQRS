using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Web.Models.v1;
using RESTCountries.Services;

namespace Hahn.ApplicatonProcess.December2020.Web.Validators.v1
{
    public class CreateApplicantModelValidator : AbstractValidator<CreateApplicantModel>
    {
        public CreateApplicantModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The name must be at least 5 character long")
                .Length(5);
            RuleFor(x => x.FamilyName)
                .NotEmpty()
                .WithMessage("The name must be at least 5 character long")
                .Length(5);
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("The name must be at least 10 character long")
                .Length(10);
            RuleFor(x => x.Age)
                .InclusiveBetween(20, 60)
                .WithMessage("The minimum age is 20 and the maximum age is 60 years");
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("Please enter the email address");
            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .WithMessage("Please enter the valid email");
            RuleFor(x => x.Hired)
                .NotNull()
                .WithMessage("Hired check should not be null or empty");
            RuleFor(x => x.CountryOfOrigin)
                .NotEmpty()
                .Must(IsValidCountryCategory).WithMessage("Select a valid country");
        }

        private bool  IsValidCountryCategory(CreateApplicantModel applicant, string homeCountry)
        {
            var validCountries =  RESTCountriesAPI.GetAllCountriesAsync().Result;

            return validCountries.Exists(x=>x.Name==homeCountry);
        }
    }
    public class UpdateApplicantModelValidator : AbstractValidator<UpdateApplicantModel>
    {
        public UpdateApplicantModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("The name must be at least 5 character long")
                .Length(5);
            RuleFor(x => x.FamilyName)
                .NotEmpty()
                .WithMessage("The name must be at least 5 character long")
                .Length(5);
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("The name must be at least 10 character long")
                .Length(10);
            RuleFor(x => x.Age)
                .InclusiveBetween(20, 60)
                .WithMessage("The minimum age is 20 and the maximum age is 60 years");
            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("Please enter the email address");
            RuleFor(x => x.EmailAddress)
                .EmailAddress()
                .WithMessage("Please enter the valid email");
            RuleFor(x => x.Hired)
                .NotNull()
                .WithMessage("Hired check should not be null or empty");
            RuleFor(x => x.CountryOfOrigin)
                .NotEmpty()
                .Must(IsValidCountryCategory).WithMessage("Select a valid country");
        }

        private bool IsValidCountryCategory(UpdateApplicantModel applicant, string homeCountry)
        {
            var validCountries = RESTCountriesAPI.GetAllCountriesAsync().Result;

            return validCountries.Exists(x => x.Name == homeCountry);
        }
    }
}
