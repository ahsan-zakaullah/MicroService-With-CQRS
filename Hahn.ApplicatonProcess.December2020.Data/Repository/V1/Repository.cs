using System;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.December2020.Data.Database;
using Hahn.ApplicatonProcess.December2020.Data.Utils;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.V1
{
    /// <summary>
    /// Base Repository.
    /// Created a generic repository with class type.
    /// </summary>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        #region private

        private readonly ApplicantDbContext _applicantContext;
        private readonly ILogger<Repository<TEntity>> _logger;

        #endregion

        #region constructors
        /// <summary>
        /// Parameterized constructor.
        /// Inject the DB context and logging dependencies.
        /// </summary>
        public Repository(ApplicantDbContext applicantContext, ILogger<Repository<TEntity>> logger)
        {
            _applicantContext = applicantContext;
            _logger = logger;
        }

        #endregion

        #region public methods

        /// <summary>
        /// Get all applicant
        /// </summary>
        /// <returns>Returns list of given entity</returns>
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
        /// <summary>
        /// Add applicant. return the custom exception if entity null. Also logs the exception if unable to save entity.
        /// </summary>
        /// <param name="entity"> take the entity as a parameter </param>
        /// <returns>Returns the created applicant</returns>
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new HahnException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _applicantContext.AddAsync(entity);
                await _applicantContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw new HahnException($"{nameof(entity)} could not be saved");
            }
        }
        /// <summary>
        /// Update applicant.
        /// Return the exception if entity null. Also logs the exception if unable to update entity.
        /// </summary>
        /// <param name="entity"> take the entity as a parameter </param>
        /// <returns>Returns the updated applicant</returns>
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _applicantContext.Update(entity);
                await _applicantContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                throw new HahnException($"{nameof(entity)} could not be updated");
            }
        }
        /// <summary>
        /// Delete applicant
        /// Returns the exception if entity null. Also logs the exception if unable to delete entity.
        /// </summary>
        /// <param name="entity"> take the entity as a parameter </param>
        /// <returns>Returns the boolean either entity deleted or not</returns>
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

        #endregion
    }
}