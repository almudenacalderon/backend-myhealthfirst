using AutoMapper;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthFirst.DTOs;

namespace MyHealthFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        public DietController(ProjectDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<DietController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diet>>> GetDiets()
        {
            if (_context.Diets == null)
            {
                return NotFound();
            }
            return await _context.Diets.Include(d => d.Meals).ToListAsync();
        }
        // GET api/<DietController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diet>> GetDiet(int id)
        {
            var diet = await _context.Diets
                .Include(d => d.Meals)
                .FirstOrDefaultAsync(d=> d.Id == id);

            if (diet == null)
            {
                return NotFound();
            }

            return diet;
        }

        // POST api/<DietController>
        [HttpPost]
        public async Task<ActionResult<Diet>> PostDiet(int NutricionistId, int ClientId, DietDTO dietDTO)
        {

            var diet = _mapper.Map<Diet>(dietDTO);
            diet.NutricionistId = NutricionistId;
            diet.ClientId = ClientId;
            // trainer.FechaNacimiento = DateTime.ParseExact(trainer.FechaNacimiento.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            _context.Diets.Add(diet);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<DietController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiet(int id, int ClientId, DietDTO dietDTO)
        {
            var diet = await _context.Diets
               .Include(d=> d.Nutricionists)
               .Include(d => d.Meals)
               .FirstOrDefaultAsync(d => d.Id == id);

            if (diet == null)
            {
                return NotFound();
            }
            _mapper.Map(dietDTO, diet);
            diet.ClientId = ClientId;

            _context.Entry(dietDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DietExists(id))
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

        // DELETE api/<DietController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiet(int id)
        {
            if (_context.Diets == null)
            {
                return NotFound();
            }
            var diet = await _context.Diets
              .Include(n => n.Meals)
              .FirstOrDefaultAsync(n => n.Id == id);

            if (diet == null)
            {
                return NotFound();
            }

            _context.Diets.Remove(diet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool DietExists(int id)
        {
            return (_context.Diets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

