namespace Biblioteca.Dtos
{
    public class LivroResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = "";
        public string Autor { get; set; } = "";
        public int Ano { get; set; } // adicionar
    }
}
