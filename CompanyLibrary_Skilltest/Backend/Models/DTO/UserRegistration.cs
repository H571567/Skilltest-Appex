using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public class UserRegistration
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
