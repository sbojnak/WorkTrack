using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WorkTrack.Core.Entities;
using WorkTrack.Logic.CommandHandlers;

namespace WorkTrack.Infrastructure
{
    public static class InfrastructureServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, string dbConnectionString)
        {
            services.AddDbContext<WorkTrackDbContext>(
                options => options.UseSqlServer(dbConnectionString), ServiceLifetime.Scoped);

            services.AddMediatR(typeof(CreateWorkRecordCommandHandler).Assembly);
        }
    }
}
