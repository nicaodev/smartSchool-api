using System.Collections.Generic;

namespace smartSchool.API.Models
{
    public class Disciplina
    {
        public Disciplina()
        { }

        public Disciplina(int id, string nomeDisciplina, int professorId, int cursoId)
        {
            this.Id = id;
            this.NomeDisciplina = nomeDisciplina;
            this.ProfessorId = professorId;
            this.CursoId = cursoId;
        }

        public int Id { get; set; }
        public int CargaHoraria { get; set; }
        public string NomeDisciplina { get; set; }
        public int ProfessorId { get; set; } // Padrao do EF, o EF já entende que está referenciando o ID da classe Professor.

        public Professor Professor { get; set; }

        public int CursoId { get; set; }
        public Curso Curso { get; set; }

        // Auto relacionamento com disciplina
        public int? PrerequisitoId { get; set; } = null;

        public Disciplina Prerequisito { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}