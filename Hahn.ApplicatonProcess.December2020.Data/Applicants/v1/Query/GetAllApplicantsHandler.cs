using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query
{
    /// <summary>
    /// Get all applicant request handler. Inherited from MediatR handler interface accepting the request and response model
    /// </summary>
    public class GetAllApplicantsHandler : IRequestHandler<GetAllApplicantsQuery, List<Applicant>>
    {
        private readonly IRepository<Applicant> _repository;
        // Inject the repository of applicant type in the constructor
        public GetAllApplicantsHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Handle method to get request and response accordingly.
        /// <param name="request"> Applicants query request </param>
        /// /// <param name="cancellationToken"> Pass cancellation token </param>
        /// <returns>Returns the list of applicants</returns>
        /// </summary>
        public async Task<List<Applicant>> Handle(GetAllApplicantsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().ToListAsync(cancellationToken: cancellationToken);
        }
    }
}