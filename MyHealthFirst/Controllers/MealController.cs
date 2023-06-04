using AutoMapper;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthFirst.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHealthFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        public MealController(ProjectDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        // GET: api/<MealController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetMeals()
        {
            if (_context.Meals == null)
            {
                return NotFound();
            }
            return await _context.Meals.ToListAsync();
        }
        // GET api/<MealController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(int id)
        {
            var meal = await _context.Meals.FindAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        // POST api/<MealController>
        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(int DietId, MealDTO mealDTO)
        {
            var meal = _mapper.Map<Meal>(mealDTO);
            meal.DietId = DietId;
            // trainer.FechaNacimiento = DateTime.ParseExact(trainer.FechaNacimiento.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT api/<MealController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, MealDTO mealDTO)
        {
            var meal = await _context.Meals
               .Include(m => m.Diet)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (meal == null)
            {
                return NotFound();
            }
            _mapper.Map(mealDTO, meal);

            _context.Entry(mealDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
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

        // DELETE api/<MealController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            if (_context.Meals == null)
            {
                return NotFound();
            }
            var meal = await _context.Meals.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool MealExists(int id)
        {
            return (_context.Meals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
