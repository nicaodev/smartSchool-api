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

        public Aluno[] GetAlunosByDisciplinasId(int disciplinaId, bool incluirProfessor = false)
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

        public Aluno GetAlunoById(int alunoId, bool incluirProfessor = false)
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

        public Professor[] GetProfessores()
        {
            throw new System.NotImplementedException();
        }

        public Professor[] GetProfessoresByDisciplinasId()
        {
            throw new System.NotImplementedException();
        }

        public Professor GetGetProfessoreById()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_c.SaveChanges() > 0);
        }
    }
}
