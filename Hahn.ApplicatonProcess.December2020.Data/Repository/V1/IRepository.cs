using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.V1
{
    /// <summary>
    /// Repository interface.
    /// Created a generic repository with class type.
    /// </summary>
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Get all applicant
        /// </summary>
        /// <returns>Returns list of given entity</returns>
        IQueryable<TEntity> GetAll();
        /// <summary>
        /// Add applicant
        /// </summary>
        /// <param name="entity"> take the entity as a parameter </param>
        /// <returns>Returns the created applicant</returns>
        Task<TEntity> AddAsync(TEntity entity);
        /// <summary>
        /// Update applicant
        /// </summary>
        /// <param name="entity"> take the entity as a parameter </param>
        /// <returns>Returns the updated applicant</returns>
        Task<TEntity> UpdateAsync(TEntity entity);
        /// <summary>
        /// Delete applicant
        /// </summary>
        /// <param name="entity"> take the entity as a parameter </param>
        /// <returns>Returns the boolean either entity deleted or not</returns>
        Task<bool> DeleteAsync(TEntity entity);
    }
}
