using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    /// <summary>
    /// Update applicant request. Inherited from MediatR request interface accepting the request and response model
    /// </summary>
    public class UpdateApplicantCommand : IRequest<Applicant>
    {
        // Applicant property which will be use to update the record
        public Applicant Applicant { get; set; }
    }
}