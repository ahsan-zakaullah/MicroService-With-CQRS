using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    /// <summary>
    /// Update applicant request handler. Inherited from MediatR handler interface accepting the request and response model
    /// </summary>
    public class UpdateApplicantCommandHandler : IRequestHandler<UpdateApplicantCommand, Applicant>
    {
        private readonly IRepository<Applicant> _repository;
        // Inject the repository of applicant type in the constructor
        public UpdateApplicantCommandHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Handle method to get request and response accordingly.
        /// <param name="request"> Applicants command request </param>
        /// /// <param name="cancellationToken"> Pass cancellation token </param>
        /// <returns>Returns the created applicants</returns>
        /// </summary>
        public async Task<Applicant> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Applicant);
            
        }
    }
}