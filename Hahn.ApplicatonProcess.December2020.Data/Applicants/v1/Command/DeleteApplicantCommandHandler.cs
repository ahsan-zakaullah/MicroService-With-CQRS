using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    public class DeleteApplicantCommandHandler : IRequestHandler<DeleteApplicantCommand, bool>
    {
        private readonly IRepository<Applicant> _repository;

        public DeleteApplicantCommandHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var isDelete = await _repository.DeleteAsync(request.Applicant);
            return isDelete;
        }
    }
}