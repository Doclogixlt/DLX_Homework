using DataAccess.Entities;
using DataAccess.Models.UserModels;
using DLXLogsBL.Contracts;
using Repository.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace DLXLogsBL.Services
{
    using BCrypt.Net;

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryManager _repository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IRepositoryManager repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<User?> Register(RegisterModel model)
        {
            try
            {
                var user = _repository.User.GetUser(model.Name);
                if (user == null)
                {
                    user = model.ToUserEntity(BCrypt.HashPassword(model.Password));
                    await _repository.User.AddUser(user);
                    await _repository.SaveAsync();
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Something went wrong. PLease try later.");
            }
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var user = _repository.User.GetUser(loginModel.Name);

            if (user == null || BCrypt.Verify(loginModel.Password, user.Password) == false)
            {
                return "";
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name)
                }),
                IssuedAt = DateTime.UtcNow,
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"],
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
