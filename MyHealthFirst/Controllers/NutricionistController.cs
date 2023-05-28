using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyHealthFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutricionistController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        public NutricionistController(ProjectDBContext context)
        {
            _context = context;
        }

        // GET: api/Nutricionist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nutricionist>>> GetNutricionists()
        {
            if (_context.Nutricionists == null)
            {
                return NotFound();
            }
            return await _context.Nutricionists.ToListAsync();
        }

        // GET: api/Nutricionist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nutricionist>> GetNutricionist(int id)
        {
            var nutricionist = await _context.Nutricionists.FindAsync(id);

            if (nutricionist == null)
            {
                return NotFound();
            }

            return nutricionist;
        }

        // PUT: api/Nutricionist/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNutricionist(int id, Nutricionist nutricionist)
        {
            if (id != nutricionist.Id)
            {
                return BadRequest();
            }

            _context.Entry(nutricionist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NutricionistExists(id))
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

        // DELETE: api/Nutricionist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutricionist(int id)
        {
            if (_context.Nutricionists == null)
            {
                return NotFound();
            }
            var nutricionist = await _context.Nutricionists.FindAsync(id);
            if (nutricionist == null)
            {
                return NotFound();
            }

            _context.Nutricionists.Remove(nutricionist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NutricionistExists(int id)
        {
            return (_context.Nutricionists?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

