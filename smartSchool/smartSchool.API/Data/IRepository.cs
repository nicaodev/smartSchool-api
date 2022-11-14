using smartSchool.API.Models;

namespace smartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Escopo Alunos
        Aluno[] GetAlunos(bool incluirProfessor);
        Aluno[] GetAlunosByDisciplinasId(int disciplinaId, bool incluirProfessor = false);
        Aluno GetAlunoById(int alunoId, bool incluirProfessor = false);

        // Escopo Professor

        Professor[] GetProfessores(bool incluiAlunos = false);
        Professor[] GetProfessoresByDisciplinasId(int disciplinaId, bool incluirAluno = false);
        Professor GetProfessoreById(int professorId, bool incluirAluno = false);
    }
}
