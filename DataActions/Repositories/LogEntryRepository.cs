using DataActions.DataModels;

namespace DataActions.Repositories
{
    public class LogEntryRepository
    {
        private readonly ApplicationDbContext _context;

        public LogEntryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveBatchAsync(IEnumerable<LogEntry> logEntries)
        {
            _context.LogEntries.AddRange(logEntries);
            await _context.SaveChangesAsync();
        }
    }
}
