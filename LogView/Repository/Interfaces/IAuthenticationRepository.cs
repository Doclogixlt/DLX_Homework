using DataAccess.Entities;
using Models.UserModels;

namespace Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        User? GetUserAsync(string name);
        void Add(User user);    
    }
}
