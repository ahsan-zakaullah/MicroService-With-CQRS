using System.Collections.Generic;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using MediatR;

namespace Hahn.ApplicatonProcess.December2020.Data.Applicants.v1.Query
{
    /// <summary>
    /// Get all applicant request. Inherited from MediatR request interface accepting the request and response model
    /// </summary>
    public class GetAllApplicantsQuery : IRequest<List<Applicant>>
    {
    }
}