using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand, Applicant>
    {
        private readonly IRepository<Applicant> _repository;

        public UpdateApplicantCommandHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }

        public async Task<Applicant> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await _repository.UpdateAsync(request.Applicant);
            return applicant;
        }
    }
}