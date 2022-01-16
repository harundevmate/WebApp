using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBusiness.Interfaces
{

    public interface IRepository<TEntity> where TEntity : class,IEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(string id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
        Task<TEntity> GetByIdAsNoTrackingAsync(string id);
    }
}
