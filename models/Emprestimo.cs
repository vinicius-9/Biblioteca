using System;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Emprestimo
    {
        [Key]
        public int Id { get; set; }

        public int LivroId { get; set; }
        public Livro Livro { get; set; } = null!;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; } = null!;

        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
