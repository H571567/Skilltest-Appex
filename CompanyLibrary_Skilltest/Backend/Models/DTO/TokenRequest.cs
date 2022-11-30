using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTO
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
