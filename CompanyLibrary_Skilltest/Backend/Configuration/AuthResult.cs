using Backend.Models.DTO;

namespace Backend.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public TokenUser User { get; set; }
        public List<string> Errors { get; set; }
    }
}
