using System;

namespace smartSchool.API.DTOs
{
    /// <summary>
    /// DTO para retorno de informações de Aluno.
    /// </summary>
    public class AlunoDto
    {
        public int Id { get; set; }
        /// <summary>
        /// Nome do Aluno
        /// </summary>
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataIni { get; set; }
        public bool Ativo { get; set; }
    }
}