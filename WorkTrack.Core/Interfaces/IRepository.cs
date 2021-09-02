using System.Collections.Generic;
using System.Threading.Tasks;

namespace WorkTrack.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> CreateAsync(TEntity entityToCreate);
    }
}
