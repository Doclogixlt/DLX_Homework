using DataAccess;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly LogsDbContext _context;
        public RepositoryBase(LogsDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }
    }
}
