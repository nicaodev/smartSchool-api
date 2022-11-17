using smartSchool.API.Helpers;
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

        Task<PageList<Aluno>> GetAlunosAsync(PageParams pageParams, bool incluirProfessor);

        Task<Aluno[]> GetAlunosByDisciplinasIdAsync(int disciplinaId, bool incluirProfessor);

        Task<Aluno> GetAlunoByIdAsync(int alunoId, bool incluirProfessor);

        // Escopo Professor

        Task<Professor[]> GetProfessoresAsync(bool incluiAlunos);

        Task<Professor[]> GetProfessoresByDisciplinasIdAsync(int disciplinaId, bool incluirAluno);

        Task<Professor> GetProfessoreByIdAsync(int professorId, bool incluirAluno);
    }
}