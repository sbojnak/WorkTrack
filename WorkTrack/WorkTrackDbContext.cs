using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkTrack
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
