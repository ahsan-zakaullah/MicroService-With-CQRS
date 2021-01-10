using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    public class CreateApplicantCommand : IRequest<Applicant>
    {
        public Applicant Applicant { get; set; }
    }
}