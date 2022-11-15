using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace smartSchool.API.Models
{
    public class Curso
    {
        public Curso()
        {

        }

        public Curso(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Disciplina> Disciplina { get; set; }
    }
}
