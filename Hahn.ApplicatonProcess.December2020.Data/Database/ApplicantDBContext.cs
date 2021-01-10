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
            //var applicant = new[]
            //{
            //    new Applicant
            //    {
            //        Name = "Ahsan",
            //        FamilyName = "Zaka Ullah",
            //        Address = "Intagleo Systems",
            //        CountryOfOrigin = "Pakistan",
            //        EmailAddress = "ahsanzakaullah@gmail.com",
            //        Age = 30,
            //        Hired = true
            //    }
            //};

            //Applicants.AddRange(applicant);
            //SaveChanges();
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
                entity.HasKey(x => x.Id);
                entity.Property(e => e.EmailAddress).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.FamilyName).IsRequired();
                //entity.HasData(new Applicant("Seeding", "Zaka Ullah", "Intagleo Systems", "Pakistan", "ahsanzakaullah@gmail.com", 30, true));
            });
        }
    }
}
