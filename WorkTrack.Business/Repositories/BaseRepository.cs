using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkTrack.Core.Interfaces;

namespace WorkTrack.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        private readonly WorkTrackDbContext workTrackDbContext;

        public BaseRepository(WorkTrackDbContext workTrackDbContext)
        {
            this.workTrackDbContext = workTrackDbContext;
        }

        public async Task<T> CreateAsync(T entityToCreate)
        {
            workTrackDbContext.Set<T>().Add(entityToCreate);
            await workTrackDbContext.SaveChangesAsync();
            return entityToCreate;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await workTrackDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await workTrackDbContext.Set<T>().FindAsync(id);
        }
    }
}
