
using AutoMapper;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthFirst.DTOs;
using System.Globalization;

namespace MyHealthFirst.Controllers
{
    [Route("api")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ProjectDBContext _context;
        private readonly IMapper _mapper;
        public ClientController(ProjectDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Client
        [HttpGet("[controller]")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("[controller]/{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients
                .Include(c => c.Trainer)
                .Include(c => c.Nutricionist)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Client/5
        [HttpPut("[controller]/{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Client
        [HttpPost("[controller]")]
        public async Task<ActionResult<Client>> PostClient(ClientDTO clientDTO)
        {
            var yaExisteCliente = await _context.Clients.AnyAsync(c => c.Email == clientDTO.Email);

            if (yaExisteCliente)
            {
                return BadRequest("Ya existe un cliente con este email" + clientDTO.Email);
            }
            var client = _mapper.Map<Client>(clientDTO);

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Client/5
        [HttpDelete("[controller]/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return (_context.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
