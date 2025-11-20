namespace Biblioteca.Models;

public class Emprestimo
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public int MembroId { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataPrevista { get; set; }
}
