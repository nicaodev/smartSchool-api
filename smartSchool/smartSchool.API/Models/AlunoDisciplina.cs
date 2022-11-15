using System;

namespace smartSchool.API.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()
        { }

        public AlunoDisciplina(int alunoId, int disciplinaID)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaID;
        }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public int? Nota { get; set; } = null;
    }
}