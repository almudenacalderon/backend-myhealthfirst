using AutoMapper;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthFirst.DTOs;
using System.Globalization;

namespace MyHealthFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        public TrainerController(ProjectDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
   
        // GET: api/Trainer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
        {
            if (_context.Trainers == null)
            {
                return NotFound();
            }
            return await _context.Trainers.ToListAsync();
        }

        // GET: api/Trainer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);

            if (trainer == null)
            {
                return NotFound();
            }

            return trainer;
        }

        // PUT: api/Trainer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, Trainer trainer)
        {
            if (id != trainer.Id)
            {
                return BadRequest();
            }

            _context.Entry(trainer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrainerExists(id))
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

        // POST: api/Trainer
        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer(TrainerDTO trainerDTO)
        {
            var trainer = _mapper.Map<Trainer>(trainerDTO);

           // trainer.FechaNacimiento = DateTime.ParseExact(trainer.FechaNacimiento.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Trainer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            if (_context.Trainers == null)
            {
                return NotFound();
            }
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainerExists(int id)
        {
            return (_context.Trainers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
