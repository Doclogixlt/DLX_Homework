using DataAccess.Entities;

namespace Repository.Contracts
{
    public interface IUserRepository
    {
        User? GetUser(string name);
        Task AddUser(User user);
    }
}
