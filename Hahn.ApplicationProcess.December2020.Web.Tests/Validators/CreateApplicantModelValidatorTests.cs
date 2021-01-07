using FluentValidation.TestHelper;
using Hahn.ApplicatonProcess.December2020.Web.Validators.v1;
using Xunit;

namespace Hahn.ApplicationProcess.December2020.Web.Tests.Validators
{
    // TODO: Need to add more test cases for validations
    public class CreateApplicantModelValidatorTests
    {
        private readonly CreateApplicantModelValidator _test;

        public CreateApplicantModelValidatorTests()
        {
            _test = new CreateApplicantModelValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        public void FirstName_WhenShorterThanFiveCharacter_ShouldHaveValidationError(string firstName)
        {
            _test.ShouldHaveValidationErrorFor(x => x.Name, firstName).WithErrorMessage("The name must be at least 5 character long");
        }

        [Theory]
        [InlineData("")]
        [InlineData("a")]
        public void FamilyName_WhenShorterThanFiveCharacter_ShouldHaveValidationError(string familyName)
        {
            _test.ShouldHaveValidationErrorFor(x => x.FamilyName, familyName).WithErrorMessage("The family name must be at least 5 character long");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("Berlin")]
        public void Address_WhenShorterThanTenCharacter_ShouldHaveValidationError(string address)
        {
            _test.ShouldHaveValidationErrorFor(x => x.Address, address).WithErrorMessage("The address must be at least 10 character long");
        }
        [Theory]
        [InlineData("")]
        public void EmailAddress_WhenEmptyOrNull_ShouldHaveValidationError(string emailAddress)
        {
            _test.ShouldHaveValidationErrorFor(x => x.EmailAddress, emailAddress).WithErrorMessage("Please enter the email address");
        }
        [Theory]
        [InlineData("ahsanzakaullah")]
        public void EmailAddress_WhenFormatNotValid_ShouldHaveValidationError(string emailAddress)
        {
            _test.ShouldHaveValidationErrorFor(x => x.EmailAddress, emailAddress).WithErrorMessage("Please enter the valid email");
        }
        [Theory]
        [InlineData(19)]
        [InlineData(61)]
        public void Age_WhenLessThan20OrGreaterThan60_ShouldHaveValidationError(int age)
        {
            _test.ShouldHaveValidationErrorFor(x => x.Age, age).WithErrorMessage("The minimum age is 20 and the maximum age is 60 years");
        }
        [Theory]
        [InlineData(20)]
        [InlineData(60)]
        public void Age_WhenBetween20And60_ShouldNotHaveValidationError(int age)
        {
            _test.ShouldNotHaveValidationErrorFor(x => x.Age, age);
        }

        [Fact]
        public void FirstName_WhenLongerThanFourCharacter_ShouldNotHaveValidationError()
        {
            _test.ShouldNotHaveValidationErrorFor(x => x.Name, "Ahsan");
        }

        [Fact]
        public void LastName_WhenLongerThanFourCharacter_ShouldNotHaveValidationError()
        {
            _test.ShouldNotHaveValidationErrorFor(x => x.FamilyName, "ZakaUllah");
        }
    }
}