using System;

namespace Biblioteca.Dtos
{
    public class EmprestimoResponse
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; } // adicionar
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataPrevista { get; set; }
        public DateTime? DataDevolucao { get; set; } // adicionar
    }
}
