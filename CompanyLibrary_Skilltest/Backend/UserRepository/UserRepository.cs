using System.Security.Claims;

namespace Backend.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(IHttpContextAccessor httpContextAccessor) =>
            _httpContextAccessor = httpContextAccessor;

        public string LogCurrentUser()
        {
            var result = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {

                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

            }
            return result;
        }
    }
}
