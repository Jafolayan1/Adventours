using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,8}$", ErrorMessage = "Password must be 6 digit or more and requires Upper and lower case letter")]
        public string Password { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}