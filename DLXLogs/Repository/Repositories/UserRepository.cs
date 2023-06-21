using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(LogsDbContext context) : base(context)
        {
        }

        public User? GetUser(string name)
        {
            var query = Get();
            var user = query.FirstOrDefault(u => u.Name == name);
            return user;
        }

        public async Task AddUser(User user)
            => await Add(user);
    }
}
