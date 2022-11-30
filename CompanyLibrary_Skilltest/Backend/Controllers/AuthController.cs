using Backend.Configuration;
using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly JwtConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParams;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(UserManager<AppUser> userManager, DataContext context, JwtConfig jwtConfig, TokenValidationParameters tokenValidationParams, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _context = context;
            _jwtConfig = jwtConfig;
            _tokenValidationParams = tokenValidationParams;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistration user)
        {
            if (ModelState.IsValid) {

                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Email already in use"
                        },
                        Success = false
                    });
                }

            }

            var newUser = new AppUser()
            {
                Email = user.Email,
                UserName = user.Email,
                Name = user.Name
            };
            var isCreated = await _userManager.CreateAsync(newUser, user.Password);

            if (isCreated.Succeeded)
            {
                var jwtToken = await GenerateJwtToken(newUser);
                return Ok(jwtToken);
            }
            else
            {
                return BadRequest(new RegistrationResponse()
                {
                    Errors = new List<string>()
                {
                    "Invalid Payload"
                },
                    Success = false
                });
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid login request"
                        },
                        Success = false
                    });
                }


                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (!isCorrect)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>()
                        {
                            "Invalid login request"
                        },
                        Success = false

                    });
                }

                var jwtToken = await GenerateJwtToken(existingUser);

                Response.Cookies.Append("token", jwtToken.Token, new CookieOptions()
                {
                    HttpOnly = true
                });

                jwtToken.Token = null;
                return Ok(jwtToken);
            }

            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>()
                {
                    "Invalid Payload"
                },
                Success = false
            });
        }

        private async Task<AuthResult> GenerateJwtToken(AppUser user)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Name, user.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            TokenUser tokenUser = new TokenUser()
            {
                UserId = user.Id,
                Email = user.Email,
                Name = user.Name
            };

            return new AuthResult()
            {
                Token = jwtToken,
                Success = true,
                User = tokenUser
            };

        }

        [HttpGet]
        [Route("CheckToken")]
        public async Task<IActionResult> CheckToken()
        {
            if (HttpContext.Request.Cookies["token"] != null)
            {
                string token = _httpContextAccessor.HttpContext.Request.Cookies["token"];

                JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

                var tokenInVerification = jwtTokenHandler.ValidateToken(token, _tokenValidationParams, out var validatedToken);

                var jsonToken = jwtTokenHandler.ReadJwtToken(token);

                var ema = jsonToken.Claims.First(claim => claim.Type == "email").Value;

                AppUser use = await _userManager.FindByEmailAsync(ema);

                TokenUser tokenUser = new TokenUser()
                {
                    UserId = use.Id,
                    Email = use.Email,
                    Name = use.Name
                };

                return Ok(new RegistrationResponse()
                {
                    Success = true,
                    User = tokenUser
                });

            }
            else
            {
                return BadRequest(new RegistrationResponse()
                {
                    Errors = new List<String>()
                    {
                        "No cookies"
                    },
                    Success = false,
                    User = null
                });
            }
        }

        [HttpDelete]
        [Route("deletetokens")]
        public async Task<IActionResult> DeleteCookiesAndRefreshToken()
        {
            string token = _httpContextAccessor.HttpContext.Request.Cookies["token"];

            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }

            var jsonToken = jwtTokenHandler.ReadJwtToken(token);

            var userId = jsonToken.Claims.First(claim => claim.Type == "Id").Value;

            return NoContent();

        }

        private DateTime UnixTimeStampToDateTime(long timeStamp)
        {
            var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeVal = dateTimeVal.AddSeconds(timeStamp).ToUniversalTime();
            return dateTimeVal;
        }

        private string RandomString(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(x => x[random.Next(x.Length)]).ToArray());
        }
    }
}
