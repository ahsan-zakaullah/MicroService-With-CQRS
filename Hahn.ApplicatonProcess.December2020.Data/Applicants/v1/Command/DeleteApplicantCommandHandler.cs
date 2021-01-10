using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Repository.V1;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    /// <summary>
    /// Delete applicant request handler. Inherited from MediatR handler interface accepting the request and response model
    /// </summary>
    public class DeleteApplicantCommandHandler : IRequestHandler<DeleteApplicantCommand, bool>
    {
        private readonly IRepository<Applicant> _repository;
        // Inject the repository of applicant type in the constructor
        public DeleteApplicantCommandHandler(IRepository<Applicant> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Handle method to get request and response accordingly.
        /// <param name="request"> Applicants command request </param>
        /// /// <param name="cancellationToken"> Pass cancellation token </param>
        /// <returns>Returns the boolean status either applicant deleted or not</returns>
        /// </summary>
        public async Task<bool> Handle(DeleteApplicantCommand request, CancellationToken cancellationToken)
        {
            var isDelete = await _repository.DeleteAsync(request.Applicant);
            return isDelete;
        }
    }
}