using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Dtos;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly AppDbContext _context;
    public EmprestimoController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmprestimoResponse>>> GetEmprestimos()
    {
        var emprestimos = await _context.Emprestimos
            .Include(e => e.Cliente)
            .Include(e => e.Funcionario)
            .Include(e => e.Livro)
            .ToListAsync();

        return emprestimos.Select(e => new EmprestimoResponse
        {
            Id = e.Id,
            ClienteId = e.ClienteId,
            LivroId = e.LivroId,
            FuncionarioId = e.FuncionarioId,
            DataEmprestimo = e.DataEmprestimo,
            DataPrevista = e.DataPrevista,
            DataDevolucao = e.DataDevolucao
        }).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmprestimoResponse>> GetEmprestimo(int id)
    {
        var e = await _context.Emprestimos.FindAsync(id);
        if (e == null) return NotFound();

        return new EmprestimoResponse
        {
            Id = e.Id,
            ClienteId = e.ClienteId,
            LivroId = e.LivroId,
            FuncionarioId = e.FuncionarioId,
            DataEmprestimo = e.DataEmprestimo,
            DataPrevista = e.DataPrevista,
            DataDevolucao = e.DataDevolucao
        };
    }

    [HttpPost]
    public async Task<ActionResult<EmprestimoResponse>> PostEmprestimo(EmprestimoRequest request)
    {
        var e = new Emprestimo
        {
            ClienteId = request.ClienteId,
            LivroId = request.LivroId,
            FuncionarioId = request.FuncionarioId,
            DataEmprestimo = DateTime.Now,
            DataPrevista = request.DataPrevista
        };

        _context.Emprestimos.Add(e);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetEmprestimo),
            new { id = e.Id },
            new EmprestimoResponse
            {
                Id = e.Id,
                ClienteId = e.ClienteId,
                LivroId = e.LivroId,
                FuncionarioId = e.FuncionarioId,
                DataEmprestimo = e.DataEmprestimo,
                DataPrevista = e.DataPrevista
            }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmprestimo(int id, EmprestimoRequest request)
    {
        var e = await _context.Emprestimos.FindAsync(id);
        if (e == null) return NotFound();

        e.ClienteId = request.ClienteId;
        e.LivroId = request.LivroId;
        e.FuncionarioId = request.FuncionarioId;
        e.DataPrevista = request.DataPrevista;

        _context.Entry(e).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmprestimo(int id)
    {
        var e = await _context.Emprestimos.FindAsync(id);
        if (e == null) return NotFound();

        _context.Emprestimos.Remove(e);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
