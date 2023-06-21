using System.ComponentModel.DataAnnotations;

namespace Model.UserModels
{
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
