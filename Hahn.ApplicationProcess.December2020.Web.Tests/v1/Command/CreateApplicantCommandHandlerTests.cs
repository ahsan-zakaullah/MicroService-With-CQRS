using FakeItEasy;
using FluentAssertions;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Xunit;

namespace Hahn.ApplicationProcess.December2020.Web.Tests.v1.Command
{
    public class CreateApplicantCommandHandlerTests
    {
        private readonly CreateApplicantCommandHandler _test;
        private readonly IRepository<Applicant> _repository;

        public CreateApplicantCommandHandlerTests()
        {
            _repository = A.Fake<IRepository<Applicant>>();
            _test = new CreateApplicantCommandHandler(_repository);
        }

        [Fact]
        public async void Handle_ShouldCallAddAsync()
        {
            await _test.Handle(new CreateApplicantCommand(), default);

            A.CallTo(() => _repository.AddAsync(A<Applicant>._)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async void Handle_ShouldReturnTrue()
        {
            A.CallTo(() => _repository.AddAsync(A<Applicant>._)).Returns(true);

            var result = await _test.Handle(new CreateApplicantCommand(), default);

            result.Should().BeTrue();
        }
    }
}