using Microsoft.AspNetCore.Mvc;
using Biblioteca.Data;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembroController : ControllerBase
{
    private readonly AppDbContext _context;

    public MembroController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Membro>>> GetMembros()
    {
        return await _context.Membros.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Membro>> GetMembro(int id)
    {
        var membro = await _context.Membros.FindAsync(id);
        if (membro == null)
            return NotFound();

        return membro;
    }

    [HttpPost]
    public async Task<ActionResult<Membro>> PostMembro(Membro membro)
    {
        _context.Membros.Add(membro);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMembro), new { id = membro.Id }, membro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutMembro(int id, Membro membro)
    {
        if (id != membro.Id)
            return BadRequest();

        _context.Entry(membro).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMembro(int id)
    {
        var membro = await _context.Membros.FindAsync(id);
        if (membro == null)
            return NotFound();

        _context.Membros.Remove(membro);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
