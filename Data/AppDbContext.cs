using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Livro> Livros => Set<Livro>();
    public DbSet<Membro> Membros => Set<Membro>();
    public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();
}
