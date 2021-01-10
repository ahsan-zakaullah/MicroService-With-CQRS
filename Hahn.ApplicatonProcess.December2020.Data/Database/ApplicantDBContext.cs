using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Database
{
    /// <summary>
    /// Application DB Context and inherited from DBContext.
    /// </summary>
    public class ApplicantDbContext : DbContext
    {
        #region Constructors
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

        #endregion

        #region protected
        /// <summary>
        /// Overriding the OnConfiguring method of DBContext to configure any entity.
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        /// <summary>
        /// Overriding the On model creating method of DBContext to define the entity relation and any seeding data.
        /// </summary>
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

        #endregion

        #region public
        /// <summary>
        /// Define the applicants property.
        /// </summary>
        public DbSet<Applicant> Applicants { get; set; }

        #endregion
    }
}
