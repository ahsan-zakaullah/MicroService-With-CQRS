using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Data.Repository.V1
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<bool> AddAsync(TEntity entity);

        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
