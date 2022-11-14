using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smartSchool.API.Data;
using smartSchool.API.Models;
using System.Linq;

namespace smartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRepository _repo;

        public AlunoController(IRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("O Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpGet("byName")]
        public IActionResult GetById(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome == nome && a.Sobrenome == sobrenome);

            if (aluno == null) return BadRequest("Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não cadastrado.");

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var retornaAluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (retornaAluno == null) return BadRequest("O Aluno não encontrado.");

            _repo.Update(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não atualizado.");

            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var retornaAluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (retornaAluno == null) return BadRequest("O Aluno não encontrado.");

            _repo.Update(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não atualizado.");

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não encontrado.");

            _repo.Delete(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não Deletado.");

            return Ok("Aluno deletado.");
        }
    }
}