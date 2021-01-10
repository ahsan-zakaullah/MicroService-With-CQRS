using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    /// <summary>
    /// Create applicant request. Inherited from MediatR request interface accepting the request and response model
    /// </summary>
    public class CreateApplicantCommand : IRequest<Applicant>
    {
        // Applicant property which will be use to create the record
        public Applicant Applicant { get; set; }
    }
}