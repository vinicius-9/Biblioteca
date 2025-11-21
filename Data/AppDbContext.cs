using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
        public DbSet<Livro> Livros => Set<Livro>();
        public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();
    }
}
