using DataAccess;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private LogsDbContext _context;
        private IUserRepository _userRepository;
        private ILogRepository _logRepository;

        public RepositoryManager(LogsDbContext context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public ILogRepository Log
        {
            get
            {
                if (_logRepository == null)
                {
                    _logRepository = new LogRepository(_context);
                }
                return _logRepository;
            }
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
