using DataAccess.Entities;
using Microsoft.IdentityModel.Tokens;
using Models.UserModels;

namespace BusinessLogic.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<User?> Register(RegisterModel registerModel);
        public Task<string?> Login(LoginModel loginModel);
    }
}
