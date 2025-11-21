namespace Biblioteca.Dtos
{
    public class PessoaRequest
    {
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public string? Numero { get; set; } // opcional
    }
}
