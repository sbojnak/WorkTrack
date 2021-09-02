using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkTrack.Core.Interfaces;
using WorkTrack.Infrastructure.Repositories;

namespace WorkTrack.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddRepository<TEntity>(this IServiceCollection services)
            where TEntity : class
        {
            services.AddScoped<IRepository<TEntity>, BaseRepository<TEntity>>();
        }

        public static void AddInfrastructure(this IServiceCollection services, string dbConnectionString)
        {
            services.AddDbContext<WorkTrackDbContext>(
                options => options.UseSqlServer(dbConnectionString), ServiceLifetime.Scoped);
        }
    }
}
