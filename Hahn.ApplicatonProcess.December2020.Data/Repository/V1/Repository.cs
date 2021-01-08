using System;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Database;
using Hahn.ApplicatonProcess.December2020.Data.Utils;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.V1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicantDbContext _applicantContext;
        private readonly ILogger<Repository<TEntity>> _logger;

        public Repository(ApplicantDbContext applicantContext, ILogger<Repository<TEntity>> logger)
        {
            _applicantContext = applicantContext;
            _logger = logger;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return  _applicantContext.Set<TEntity>();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw new HahnException("Couldn't retrieve records");
            }
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new HahnException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _applicantContext.AddAsync(entity);
                await _applicantContext.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw new HahnException($"{nameof(entity)} could not be saved");
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _applicantContext.Update(entity);
                await _applicantContext.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw new HahnException($"{nameof(entity)} could not be updated");
            }
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }

            try
            {
                _applicantContext.Remove(entity);
                await _applicantContext.SaveChangesAsync();

                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw new HahnException($"{nameof(entity)} could not be updated");
            }
        }
    }
}