using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class LogsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }

        public LogsDbContext(DbContextOptions<LogsDbContext> options) : base(options)
        {

        }
    }
}
