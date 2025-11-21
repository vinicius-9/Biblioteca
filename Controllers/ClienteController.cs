using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Dtos;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteResponse>>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();

            var response = clientes.Select(c => new ClienteResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Cpf = c.Cpf
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponse>> GetCliente(int id)
        {
            var c = await _context.Clientes.FindAsync(id);
            if (c == null)
                return NotFound();

            var response = new ClienteResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Cpf = c.Cpf
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteResponse>> PostCliente(ClienteRequest request)
        {
            var cliente = new Cliente
            {
                Nome = request.Nome,
                Cpf = request.Cpf
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var response = new ClienteResponse
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf
            };

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteRequest request)
        {
            var c = await _context.Clientes.FindAsync(id);
            if (c == null)
                return NotFound();

            c.Nome = request.Nome;
            c.Cpf = request.Cpf;

            _context.Entry(c).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var c = await _context.Clientes.FindAsync(id);
            if (c == null)
                return NotFound();

            _context.Clientes.Remove(c);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
