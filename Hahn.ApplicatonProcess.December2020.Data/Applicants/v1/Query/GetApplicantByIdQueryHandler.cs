using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query
{
    public class GetApplicantByIdQueryHandler : IRequestHandler<GetApplicantByIdQuery, Applicant>
    {
        private readonly IRepository<Applicant> _repository;

        public GetApplicantByIdQueryHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }

        public async Task<Applicant> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}