using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    public class CreateApplicantCommandHandler : IRequestHandler<CreateApplicantCommand, bool>
    {
        private readonly IRepository<Applicant> _repository;

        public CreateApplicantCommandHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.Applicant);
        }
    }
}