using Backend.Data;
using Backend.Models;
using Backend.Models.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class CompanyController : Controller
    {
        private readonly DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }

        // GET: api/companies/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<company>>> GetCompanyFromAppUser()
        {
            return await _context.companies
                .Include(x => x.appUser).ToListAsync();
        }

        // GET: api/companies/1/single
        [HttpGet("{id}")]
        public async Task<ActionResult<company>> GetCompany(int id)
        {
            var company = await _context.companies
                .Include(x => x.appUser)
                .Where(y=> y.UserId == id)
                .FirstOrDefaultAsync();

            if (company == null)
            {
                return NotFound();
            }
            return company;
        }

        // PUT: api/companies/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, company company)
        {
            if (id != company.Id)
            {
                return BadRequest(new RegistrationResponse() { Errors = new List<string>() { "Invalid" }, Success = false });
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/companies
        [HttpPost]
        public async Task<ActionResult<company>> PostCompany(company company)
        {
            _context.companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/companies/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int i)
        {
            return _context.companies.Any(x => x.Id == i);
        }
    }
}
