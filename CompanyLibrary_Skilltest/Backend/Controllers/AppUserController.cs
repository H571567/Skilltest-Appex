using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppUserController : Controller
    {
        private readonly DataContext _context;

        public AppUserController(DataContext context)
        {
            _context = context;
        }

        // GET: api/appUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.appUsers.ToListAsync();
        }

        // GET: api/appUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int i)
        {
            var user = await _context.appUsers.FindAsync(i);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        

        // DELETE: api/appUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.appUsers.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.appUsers.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
