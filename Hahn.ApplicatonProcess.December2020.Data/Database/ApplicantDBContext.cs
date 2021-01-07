using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Database
{
    public class ApplicantDbContext : DbContext
    {
        public ApplicantDbContext()
        {
            
        }
        public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options)
            : base(options)
        {
            var applicant = new[]
            {
                new Applicant
                {
                    Id = 1,
                    Name = "Ahsan",
                    FamilyName = "Zaka Ullah",
                    Address = "Intagleo Systems",
                    CountryOfOrigin = "Pakistan",
                    EmailAddress = "ahsanzakaullah@gmail.com",
                    Age = 30,
                    Hired = true
                }
            };

            Applicants.AddRange(applicant);
            SaveChanges();
        }
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.Property(e => e.EmailAddress).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.FamilyName).IsRequired();
            });
        }
    }
}
