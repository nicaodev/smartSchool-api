using Microsoft.EntityFrameworkCore;
using smartSchool.API.Models;
using System.Linq;

namespace smartSchool.API.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _c;

        public Repository(DataContext c)
        {
            _c = c;
        }

        public void Add<T>(T entity) where T : class
        {
            _c.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _c.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _c.Update(entity);
        }

        public Aluno[] GetAlunos(bool incluirProfessor)
        {
            IQueryable<Aluno> query = _c.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(ad => ad.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();
        }

        public Aluno[] GetAlunosByDisciplinasId(int disciplinaId, bool incluirProfessor)
        {
            IQueryable<Aluno> query = _c.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(ad => ad.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));

            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool incluirProfessor)
        {
            IQueryable<Aluno> query = _c.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(ad => ad.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.Id == alunoId);

            return query.FirstOrDefault();
        }

        public Professor[] GetProfessores(bool incluiAlunos)
        {
            IQueryable<Professor> query = _c.Professores;

            if (incluiAlunos)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(b => b.AlunosDisciplinas)
                             .ThenInclude(c => c.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Professor[] GetProfessoresByDisciplinasId(int disciplinaId, bool incluirAlunos)
        {
            IQueryable<Professor> query = _c.Professores;

            if (incluirAlunos)
            {
                query = query.Include(b => b.Disciplinas)
                             .ThenInclude(c => c.AlunosDisciplinas)
                             .ThenInclude(d => d.Aluno);
            }
            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(a => a.Disciplinas.Any(d => d.AlunosDisciplinas.Any(e => e.DisciplinaId == disciplinaId)));

            return query.ToArray();
        }

        public Professor GetProfessoreById(int professorId, bool incluirAluno)
        {
            IQueryable<Professor> query = _c.Professores;

            if (incluirAluno)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(b => b.AlunosDisciplinas)
                             .ThenInclude(c => c.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(prof => prof.Id == professorId);

            return query.FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_c.SaveChanges() > 0);
        }
    }
}