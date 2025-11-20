namespace Biblioteca.Dtos;

public record EmprestimoRequest(int LivroId, int MembroId, DateTime DataPrevista);
