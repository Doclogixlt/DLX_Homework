using System.ComponentModel.DataAnnotations;

namespace Models.UserModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
