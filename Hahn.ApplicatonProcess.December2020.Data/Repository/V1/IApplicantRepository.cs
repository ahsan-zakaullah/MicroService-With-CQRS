using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.V1
{
    public interface IApplicantRepository:IRepository<Applicant>
    {
        Task<Applicant> GetCustomerByIdAsync(int id, CancellationToken cancellationToken);
    }
}
