using AutoMapper;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthFirst.DTOs;

namespace MyHealthFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        public ExerciseController(ProjectDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Exercise
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            if (_context.Exercises == null)
            {
                return NotFound();
            }
            return await _context.Exercises.ToListAsync();
        }

        // GET: api/Exercise/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return exercise;
        }
        [HttpPost]
        public async Task<ActionResult> Post(ExerciseDTO exerciseDTO)
        {

            var yaExisteEjercicioConEsteNombre = await _context.Exercises.AnyAsync(e =>
                        e.Nombre == exerciseDTO.Nombre);

            if (yaExisteEjercicioConEsteNombre)
            {
                return BadRequest("Ya existe un ejercicio con el nombre " + exerciseDTO.Nombre);
            }
            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            _context.Add(exercise);

            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Training/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, ExerciseDTO exerciseDTO)
        {

            var exercise = _mapper.Map<Exercise>(exerciseDTO);
            exercise.Id = id;

            if (exercise == null)
            {
                return NotFound();
            }

            _context.Update(exercise);
           
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Training/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            if (_context.Exercises == null)
            {
                return NotFound();
            }
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }
            _context.Exercises.Remove(exercise);

            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}

