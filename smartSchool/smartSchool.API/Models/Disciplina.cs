using System.Collections;
using System.Collections.Generic;

namespace smartSchool.API.Models
{
    public class Disciplina
    {
        public Disciplina()
        { }

        public Disciplina(int id, string nomeDisciplina, int professorId)
        {
            Id = id;
            NomeDisciplina = nomeDisciplina;
            ProfessorId = professorId;
        }

        public int Id { get; set; }
        public string NomeDisciplina { get; set; }
        public int ProfessorId { get; set; } // Padrao do EF, o EF já entende que está referenciando o ID da classe Professor.

        public Professor Professor { get; set; }

        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}