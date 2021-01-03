using FakeItEasy;
using FluentAssertions;
using Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Xunit;

namespace Hahn.ApplicationProcess.December2020.Web.Tests.v1.Command
{
    public class UpdateApplicantCommandHandlerTests
    {
        private readonly UpdateApplicantCommandHandler _test;
        private readonly IRepository<Applicant> _repository;

        public UpdateApplicantCommandHandlerTests()
        {
            _repository = A.Fake<IRepository<Applicant>>();
            _test = new UpdateApplicantCommandHandler(_repository);
        }

        [Fact]
        public async void Handle_ShouldCallApplicantUpdaterSenderSendTrue()
        {
            A.CallTo(() => _repository.UpdateAsync(A<Applicant>._)).Returns(true);

            await _test.Handle(new UpdateApplicantCommand(), default);
        }

        [Fact]
        public async void Handle_ShouldReturnTrue()
        {
            A.CallTo(() => _repository.UpdateAsync(A<Applicant>._)).Returns(true);

            var result = await _test.Handle(new UpdateApplicantCommand(), default);

            result.Should().BeTrue();
        }

        [Fact]
        public async void Handle_ShouldUpdateAsync()
        {
            await _test.Handle(new UpdateApplicantCommand(), default);

            A.CallTo(() => _repository.UpdateAsync(A<Applicant>._)).MustHaveHappenedOnceExactly();
        }
    }
}