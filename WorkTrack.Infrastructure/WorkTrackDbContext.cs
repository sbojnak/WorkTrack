using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkTrack.Core.Entities;

namespace WorkTrack.Infrastructure
{
    public class WorkTrackDbContext : DbContext
    {
        public DbSet<WorkRecord> WorkRecords { get; set; }

        public WorkTrackDbContext(DbContextOptions<WorkTrackDbContext> options)
            : base(options)
        {
        }
    }
}
