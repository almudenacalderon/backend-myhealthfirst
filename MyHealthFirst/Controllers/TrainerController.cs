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
            //añadir entrenos 
            return await _context.Trainers.Include(t => t.Trainings).Include(t => t.Clients).ToListAsync();
        }

        // GET: api/Trainer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(int id)
        {
            var trainer = await _context.Trainers
                .Include(t => t.Trainings)
                .Include(t => t.Clients)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (trainer == null)
            {
                return NotFound();
            }

            return trainer;
        }

        // PUT: api/Trainer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, TrainerDTO trainerDTO)
        {
            var trainer = await _context.Trainers
               .Include(t => t.Trainings)
               .Include(t => t.Clients)
               .FirstOrDefaultAsync(n => n.Id == id);

            if (trainer == null)
            {
                return NotFound();
            }

            _mapper.Map(trainerDTO, trainer);

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

        // DELETE: api/Trainer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            if (_context.Trainers == null)
            {
                return NotFound();
            }
            var trainer = await _context.Trainers
                .Include(t => t.Trainings)
               .FirstOrDefaultAsync(n => n.Id == id);

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
