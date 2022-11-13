using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using smartSchool.API.Data;
using smartSchool.API.Models;
using System.Linq;

namespace smartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfessorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);

            if (professor == null) return BadRequest("O Professor não encontrado.");

            return Ok(professor);
        }

        [HttpGet("byName")]
        public IActionResult GetById(string nome, string sobrenome)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Nome == nome);

            if (professor == null) return BadRequest("Professor não encontrado.");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var retornaProf = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (retornaProf == null) return BadRequest("O Professor não foi encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var retornaProf = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (retornaProf == null) return BadRequest("O Professor não encontrado.");

            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("O Professor não foi encontrado.");

            _context.Remove(professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}