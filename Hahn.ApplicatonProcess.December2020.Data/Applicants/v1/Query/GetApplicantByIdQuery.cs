using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query
{
    /// <summary>
    /// Get by Id applicant request. Inherited from MediatR request interface accepting the request and response model
    /// </summary>
    public class GetApplicantByIdQuery : IRequest<Applicant>
    {
        // Applicant property which will be use to get the record
        public int Id { get; set; }
    }
}