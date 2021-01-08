using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query
{
    public class GetAllApplicantsHandler : IRequestHandler<GetAllApplicantsQuery, List<Applicant>>
    {
        private readonly IRepository<Applicant> _repository;

        public GetAllApplicantsHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }

        public async Task<List<Applicant>> Handle(GetAllApplicantsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}