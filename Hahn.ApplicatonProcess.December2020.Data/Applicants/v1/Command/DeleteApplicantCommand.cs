using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Command
{
    public class DeleteApplicantCommand : IRequest<bool>
    {
        public Applicant Applicant { get; set; }
    }
}