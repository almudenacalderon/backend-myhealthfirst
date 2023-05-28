using AutoMapper;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHealthFirst.DTOs;

namespace MyHealthFirst.Controllers
{
    [Route("api/[controller]")]
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            return await _context.Clients.ToListAsync();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, ClientDTO updatedClient)
        {
            var client = await _context.Clients
               .Include(c => c.Trainer)
               .Include(c => c.Nutricionist)
               .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            client.Nombre = updatedClient.Nombre;
            client.PhoneNumber = updatedClient.PhoneNumber;
            client.Email = updatedClient.Email;
            client.Peso = updatedClient.Peso;
            client.Altura = updatedClient.Altura;
            client.FechaNacimiento = updatedClient.FechaNacimiento;
            client.Fecha_asignacion_dieta = updatedClient.Fecha_asignacion_dieta;
            client.Fecha_asignacion_entrenamiento = updatedClient.Fecha_asignacion_entrenamiento;

            if (updatedClient.TrainerId.HasValue)
            {
                // Obtener el entrenador correspondiente al ID proporcionado
                var trainer = await _context.Trainers.FindAsync(updatedClient.TrainerId.Value);
                if (trainer != null)
                {
                    client.Trainer = trainer; // Asignar el entrenador al cliente
                    trainer.ClientId = client.Id; // Asignar el ID del cliente al campo clienteId del entrenador
                }
            }
            if (updatedClient.NutricionistId.HasValue)
            {
                // Obtener el entrenador correspondiente al ID proporcionado
                var nutricionist = await _context.Nutricionists.FindAsync(updatedClient.NutricionistId.Value);
                if (nutricionist != null)
                {
                    client.Nutricionist = nutricionist; // Asignar el entrenador al cliente
                    nutricionist.ClientId = client.Id; // Asignar el ID del cliente al campo clienteId del nutricionista
                }
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

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
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
            // Obtener el entrenador asociado al cliente
            var trainer = await _context.Trainers.FirstOrDefaultAsync(t => t.ClientId == id);
            if (trainer != null)
            {
                trainer.ClientId = null; // Eliminar la asociación con el cliente
            }

            // Obtener el nutricionista asociado al cliente
            var nutricionist = await _context.Nutricionists.FirstOrDefaultAsync(n => n.ClientId == id);
            if (nutricionist != null)
            {
                nutricionist.ClientId = null; // Eliminar la asociación con el cliente
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
