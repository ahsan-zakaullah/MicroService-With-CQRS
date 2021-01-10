using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    /// <summary>
    /// Delete applicant request. Inherited from MediatR request interface accepting the request and response model
    /// </summary>
    public class DeleteApplicantCommand : IRequest<bool>
    {
        // Applicant property which will be use to delete the record
        public Applicant Applicant { get; set; }
    }
}