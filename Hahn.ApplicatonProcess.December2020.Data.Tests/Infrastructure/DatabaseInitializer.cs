using System.Linq;
using Hahn.ApplicatonProcess.December2020.Data.Database;
using Hahn.ApplicatonProcess.December2020.Domain.Entities;

namespace Hahn.ApplicatonProcess.December2020.Data.Tests.Infrastructure
{
    public class DatabaseInitializer
    {
        public static void Initialize(ApplicantDbContext context)
        {
            if (context.Applicants.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(ApplicantDbContext context)
        {
            var applicants = new[]
            {
                new Applicant
                {
                    Id = 1,
                    Name = "Ahsan",
                    FamilyName = "Raza",
                    Address = "Berlin",
                    EmailAddress = "ahsan.raza@intagleo.com",
                    CountryOfOrigin = "Germany",
                    Age = 30,
                    Hired = true
                },
                new Applicant
                {
                    Id = 2,
                    Name = "JJ",
                    FamilyName = "Kotze",
                    Address = "Berlin",
                    EmailAddress = "ahsan.raza@intagleo.com",
                    CountryOfOrigin = "Germany",
                    Age = 26,
                    Hired = true
                },
                new Applicant
                {
                    Id = 3,
                    Name = "Carl",
                    FamilyName = "Hibbard",
                    Address = "Liverpool",
                    EmailAddress = "ahsan.raza@intagleo.com",
                    CountryOfOrigin = "UK",
                    Age = 55,
                    Hired = true
                }
            };

            context.Applicants.AddRange(applicants);
            context.SaveChanges();
        }
    }
}