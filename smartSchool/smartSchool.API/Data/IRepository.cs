using smartSchool.API.Models;
using System.Threading.Tasks;

namespace smartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool SaveChanges();

        // Escopo Alunos

        Task<Aluno[]> GetAlunosAsync(bool incluirProfessor);

        Task<Aluno[]> GetAlunosByDisciplinasIdAsync(int disciplinaId, bool incluirProfessor);

        Task<Aluno> GetAlunoByIdAsync(int alunoId, bool incluirProfessor);

        // Escopo Professor

        Professor[] GetProfessores(bool incluiAlunos);

        Professor[] GetProfessoresByDisciplinasId(int disciplinaId, bool incluirAluno);

        Professor GetProfessoreById(int professorId, bool incluirAluno);
    }
}