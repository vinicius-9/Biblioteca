using Microsoft.AspNetCore.Mvc;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmprestimoController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmprestimoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Emprestimo>>> GetEmprestimos()
    {
        return await _context.Emprestimos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Emprestimo>> GetEmprestimo(int id)
    {
        var emp = await _context.Emprestimos.FindAsync(id);
        if (emp == null)
            return NotFound();

        return emp;
    }

    [HttpPost]
    public async Task<ActionResult<Emprestimo>> PostEmprestimo(Emprestimo emprestimo)
    {
        // Verificar se o Livro existe
        var livro = await _context.Livros.FindAsync(emprestimo.LivroId);
        if (livro == null)
            return BadRequest("Livro não encontrado.");

        // Verificar se o Membro existe
        var membro = await _context.Membros.FindAsync(emprestimo.MembroId);
        if (membro == null)
            return BadRequest("Membro não encontrado.");

        _context.Emprestimos.Add(emprestimo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEmprestimo), new { id = emprestimo.Id }, emprestimo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmprestimo(int id, Emprestimo emprestimo)
    {
        if (id != emprestimo.Id)
            return BadRequest();

        _context.Entry(emprestimo).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmprestimo(int id)
    {
        var emp = await _context.Emprestimos.FindAsync(id);
        if (emp == null)
            return NotFound();

        _context.Emprestimos.Remove(emp);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
