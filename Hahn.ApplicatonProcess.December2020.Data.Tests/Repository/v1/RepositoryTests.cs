using System;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using Hahn.ApplicatonProcess.December2020.Data.Database;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Data.Tests.Infrastructure;
using Hahn.ApplicatonProcess.December2020.Data.Utils;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Hahn.ApplicatonProcess.December2020.Data.Tests.Repository.v1
{
    public class RepositoryTests : DatabaseTestBase
    {
        private readonly ApplicantDbContext _applicantContext;
        private readonly Repository<Applicant> _testee;
        private readonly Repository<Applicant> _testeeFake;
        private readonly Applicant _newApplicant;

        public RepositoryTests()
        {
            var appLogger = A.Fake<ILogger<Repository<Applicant>>>();
            _applicantContext = A.Fake<ApplicantDbContext>();
            _testeeFake = new Repository<Applicant>(_applicantContext, appLogger);
            _testee = new Repository<Applicant>(Context, appLogger);
            _newApplicant = new Applicant
            {
                Id = 5,
                Name = "Ahsan",
                FamilyName = "Raza",
                Address = "Berlin",
                EmailAddress = "ahsan.raza@intagleo.com",
                CountryOfOrigin = "Germany",
                Age = 30,
                Hired = true
            };
        }

        [Theory]
        [InlineData("Changed")]
        public async void UpdateApplicantAsync_WhenApplicantIsNotNull_ShouldReturnTrue(string firstName)
        {
            var applicant = Context.Applicants.First();
            applicant.Name = firstName;

            var result = await _testee.UpdateAsync(applicant);

            result.Should().BeTrue();
        }

        [Fact]
        public void AddAsync_WhenEntityIsNull_ThrowsException()
        {
            _testee.Invoking(x => x.AddAsync(null)).Should().Throw<HahnException>();
        }

        [Fact]
        public void AddAsync_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _applicantContext.SaveChangesAsync(default)).Throws<Exception>();

            _testeeFake.Invoking(x => x.AddAsync(new Applicant())).Should().Throw<Exception>().WithMessage("entity could not be saved");
        }

        [Fact]
        public async void CreateApplicantAsync_WhenApplicantIsNotNull_ShouldReturnTrue()
        {
            var result = await _testee.AddAsync(_newApplicant);

            result.Should().BeTrue();
        }

        [Fact]
        public async void RemoveApplicantAsync_WhenApplicantIsNotNull_ShouldReturnTrue()
        {
            var result = await _testee.DeleteAsync(_newApplicant);

            result.Should().BeTrue();
        }

        [Fact]
        public void RemoveApplicantAsync_WhenApplicantIsNull_ThrowException()
        {
            _testee.Invoking(x => x.DeleteAsync(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async void CreateApplicantAsync_WhenApplicantIsNotNull_ShouldAddApplicant()
        {
            var applicantCount = Context.Applicants.Count();

            await _testee.AddAsync(_newApplicant);

            Context.Applicants.Count().Should().Be(applicantCount + 1);
        }

        [Fact]
        public void GetAll_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _applicantContext.Set<Applicant>()).Throws<Exception>();

            _testeeFake.Invoking(x => x.GetAll()).Should().Throw<Exception>().WithMessage("Couldn't retrieve entities");
        }

        [Fact]
        public void UpdateAsync_WhenEntityIsNull_ThrowsException()
        {
            _testee.Invoking(x => x.UpdateAsync(null)).Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdateAsync_WhenExceptionOccurs_ThrowsException()
        {
            A.CallTo(() => _applicantContext.SaveChangesAsync(default)).Throws<Exception>();

            _testeeFake.Invoking(x => x.UpdateAsync(new Applicant())).Should().Throw<Exception>().WithMessage("entity could not be updated");
        }
    }
}