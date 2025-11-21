using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Dtos;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivroController : ControllerBase
{
    private readonly AppDbContext _context;
    public LivroController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivroResponse>>> GetLivros()
    {
        return await _context.Livros
            .Select(l => new LivroResponse { Id = l.Id, Titulo = l.Titulo, Autor = l.Autor, Ano = l.Ano })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LivroResponse>> GetLivro(int id)
    {
        var l = await _context.Livros.FindAsync(id);
        if (l == null) return NotFound();

        return new LivroResponse { Id = l.Id, Titulo = l.Titulo, Autor = l.Autor, Ano = l.Ano };
    }

    [HttpPost]
    public async Task<ActionResult<LivroResponse>> PostLivro(LivroRequest request)
    {
        var l = new Livro { Titulo = request.Titulo, Autor = request.Autor, Ano = request.Ano };
        _context.Livros.Add(l);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetLivro),
            new { id = l.Id },
            new LivroResponse { Id = l.Id, Titulo = l.Titulo, Autor = l.Autor, Ano = l.Ano }
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLivro(int id, LivroRequest request)
    {
        var l = await _context.Livros.FindAsync(id);
        if (l == null) return NotFound();

        l.Titulo = request.Titulo;
        l.Autor = request.Autor;
        l.Ano = request.Ano;
        _context.Entry(l).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLivro(int id)
    {
        var l = await _context.Livros.FindAsync(id);
        if (l == null) return NotFound();

        _context.Livros.Remove(l);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
