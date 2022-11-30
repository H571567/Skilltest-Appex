using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }


        [JsonIgnore]
        public ICollection<company> companies { get; set; }
    }
}
