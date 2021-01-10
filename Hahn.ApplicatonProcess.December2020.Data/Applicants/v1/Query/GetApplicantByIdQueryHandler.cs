using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query
{
    /// <summary>
    /// Get by Id applicant request handler. Inherited from MediatR handler interface accepting the request and response model
    /// </summary>
    public class GetApplicantByIdQueryHandler : IRequestHandler<GetApplicantByIdQuery, Applicant>
    {
        private readonly IRepository<Applicant> _repository;
        // Inject the repository of applicant type in the constructor
        public GetApplicantByIdQueryHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Handle method to get request and response accordingly.
        /// <param name="request"> Applicant by Id query request </param>
        /// /// <param name="cancellationToken"> Pass cancellation token </param>
        /// <returns>Returns the applicants</returns>
        /// </summary>
        public async Task<Applicant> Handle(GetApplicantByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}