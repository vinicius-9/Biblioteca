namespace Biblioteca.Dtos
{
    public class LivroRequest
    {
        public required string Titulo { get; set; }
        public required string Autor { get; set; }
        public int Ano { get; set; } 
    }
}
