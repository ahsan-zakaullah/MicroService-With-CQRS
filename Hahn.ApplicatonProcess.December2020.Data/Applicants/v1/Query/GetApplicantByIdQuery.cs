using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query
{
    public class GetApplicantByIdQuery : IRequest<Applicant>
    {
        public int Id { get; set; }
    }
}