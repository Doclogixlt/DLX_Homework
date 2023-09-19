

using DataActions.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DataActions
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<SearchQuery> SearchQueries { get; set; }
        public DbSet<FileDetail> FileDetails { get; set; }
    }
}
