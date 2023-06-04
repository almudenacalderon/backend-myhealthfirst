using AutoMapper;
using DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthFirst.DTOs;
using System.Security.Claims;

namespace MyHealthFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutricionistController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        public NutricionistController(ProjectDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Nutricionist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nutricionist>>> GetNutricionists()
        {
            if (_context.Nutricionists == null)
            {
                return NotFound();
            }
            return await _context.Nutricionists.Include(n => n.Diets).Include(n => n.Clients).ToListAsync();
        }

        // GET: api/Nutricionist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nutricionist>> GetNutricionist(int id)
        {
            var nutricionist = await _context.Nutricionists
                .Include(n => n.Diets)
                .Include(n => n.Clients)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (nutricionist == null)
            {
                return NotFound();
            }

            return nutricionist;
        }

        // PUT: api/Nutricionist/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNutricionist(int id, NutricionistDTO nutricionistDTO)
        {
           
            var nutricionist = await _context.Nutricionists
               .Include(n => n.Diets)
               .Include(n => n.Clients)
               .FirstOrDefaultAsync(n=> n.Id == id);

            if (nutricionist == null)
            {
                return NotFound();
            }

            _mapper.Map(nutricionistDTO, nutricionist);

            _context.Entry(nutricionist).State = EntityState.Modified;
           
            await _context.SaveChangesAsync();
            return Ok();

        }

        // DELETE: api/Nutricionist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNutricionist(int id)
        {
            if (_context.Nutricionists == null)
            {
                return NotFound();
            }
            var nutricionist = await _context.Nutricionists
                .Include(n => n.Diets)
               .FirstOrDefaultAsync(n => n.Id == id);
             
            if (nutricionist == null)
            {
                return NotFound();
            }

            _context.Nutricionists.Remove(nutricionist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        
    }
}

