using System;
using Hahn.ApplicatonProcess.December2020.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Data.Tests.Infrastructure
{
    public class DatabaseTestBase : IDisposable
    {
        protected readonly ApplicantDbContext Context;

        public DatabaseTestBase()
        {
            var options = new DbContextOptionsBuilder<ApplicantDbContext>().UseInMemoryDatabase("ApplicantDatabase").Options;

            Context = new ApplicantDbContext(options);

            Context.Database.EnsureCreated();

            DatabaseInitializer.Initialize(Context);
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();

            Context.Dispose();
        }
    }
}