using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
    }
}
