using Microsoft.EntityFrameworkCore;
using smartSchool.API.Helpers;
using smartSchool.API.Models;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<PageList<Aluno>> GetAlunosAsync(PageParams pageParams, bool incluirProfessor)
        {
            IQueryable<Aluno> query = _c.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(ad => ad.AlunosDisciplinas)
                             .ThenInclude(d => d.Disciplina)
                             .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);

            //return await query.ToListAsync();

            if (!string.IsNullOrEmpty(pageParams.Nome))
            {
                query = query.Where(
                    aluno => aluno.Nome
                    .ToUpper()
                    .Contains(pageParams.Nome.ToUpper()) ||
                    aluno.Sobrenome
                    .ToUpper()
                    .Contains(pageParams.Nome));
            }
            if (pageParams.Matricula > 0)
                query = query.Where(aluno => aluno.Matricula == pageParams.Matricula);

            if (pageParams.Ativo != null)
                query = query.Where(aluno => aluno.Ativo == (pageParams.Ativo != 0));

            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<Aluno[]> GetAlunosByDisciplinasIdAsync(int disciplinaId, bool incluirProfessor)
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

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int alunoId, bool incluirProfessor)
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

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Professor[]> GetProfessoresAsync(bool incluiAlunos)
        {
            IQueryable<Professor> query = _c.Professores;

            if (incluiAlunos)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(b => b.AlunosDisciplinas)
                             .ThenInclude(c => c.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Professor[]> GetProfessoresByDisciplinasIdAsync(int disciplinaId, bool incluirAlunos)
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

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessoreByIdAsync(int professorId, bool incluirAluno)
        {
            IQueryable<Professor> query = _c.Professores;

            if (incluirAluno)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(b => b.AlunosDisciplinas)
                             .ThenInclude(c => c.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(prof => prof.Id == professorId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Professor[]> GetProfessoreByAlunoIdAsync(int alunoId, bool incluirAluno)
        {
            IQueryable<Professor> query = _c.Professores;

            if (incluirAluno)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(b => b.AlunosDisciplinas)
                             .ThenInclude(c => c.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(aluno => aluno.Disciplinas.Any(d => d.AlunosDisciplinas.Any(ad => ad.AlunoId == alunoId)));

            return await query.ToArrayAsync();
        }

        public bool SaveChanges()
        {
            return (_c.SaveChanges() > 0);
        }
    }
}