using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Database;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.V1
{
    class ApplicantRepository : Repository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApplicantDbContext customerContext) : base(customerContext)
        {
        }

        public async Task<Applicant> GetCustomerByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await new ApplicantDbContext().Applicants.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
