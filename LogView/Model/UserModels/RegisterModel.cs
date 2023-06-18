using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace Models.UserModels
{
    using BCrypt.Net;
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public string Password { get; set; }

        public User ToUserEntity()
        {
            return new User
            {
                Name = Name,
                Password = BCrypt.HashPassword(Password)
            };
        }
    }
}
