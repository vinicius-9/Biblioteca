namespace Biblioteca.Dtos
{
    public class FuncionarioRequest
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public string? Numero { get; set; } // opcional
        public required string Cargo { get; set; }
    }
}
