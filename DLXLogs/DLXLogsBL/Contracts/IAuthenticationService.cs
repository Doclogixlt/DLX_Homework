using DataAccess.Entities;
using DataAccess.Models.UserModels;

namespace DLXLogsBL.Contracts
{
    public interface IAuthenticationService
    {
        Task<User?> Register(RegisterModel registerModel);
        Task<string> Login(LoginModel loginModel);
    }
}
