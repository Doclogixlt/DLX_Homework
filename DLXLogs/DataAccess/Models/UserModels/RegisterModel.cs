using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models.UserModels
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public string Password { get; set; }

        public User ToUserEntity(string password)
        {
            return new User
            {
                Name = Name,
                Password = password
            };
        }
    }
}
