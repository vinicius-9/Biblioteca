using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Dtos;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly AppDbContext _context;
    public FuncionarioController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuncionarioResponse>>> GetFuncionarios()
    {
        return await _context.Funcionarios
            .Select(f => new FuncionarioResponse { Id = f.Id, Nome = f.Nome, Cpf = f.Cpf, Cargo = f.Cargo })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FuncionarioResponse>> GetFuncionario(int id)
    {
        var f = await _context.Funcionarios.FindAsync(id);
        if (f == null) return NotFound();

        return new FuncionarioResponse { Id = f.Id, Nome = f.Nome, Cpf = f.Cpf, Cargo = f.Cargo };
    }

    [HttpPost]
    public async Task<ActionResult<FuncionarioResponse>> PostFuncionario(FuncionarioRequest request)
    {
        var f = new Funcionario { Nome = request.Nome, Cpf = request.Cpf, Cargo = request.Cargo };
        _context.Funcionarios.Add(f);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetFuncionario),
            new { id = f.Id },
            new FuncionarioResponse
            {
                Id = f.Id,
                Nome = f.Nome,
                Cpf = f.Cpf,
                Cargo = f.Cargo
            }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutFuncionario(int id, FuncionarioRequest request)
    {
        var f = await _context.Funcionarios.FindAsync(id);
        if (f == null) return NotFound();

        f.Nome = request.Nome;
        f.Cpf = request.Cpf;
        f.Cargo = request.Cargo;
        _context.Entry(f).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFuncionario(int id)
    {
        var f = await _context.Funcionarios.FindAsync(id);
        if (f == null) return NotFound();

        _context.Funcionarios.Remove(f);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
