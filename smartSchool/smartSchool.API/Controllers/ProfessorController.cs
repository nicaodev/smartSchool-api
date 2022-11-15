using Microsoft.AspNetCore.Mvc;
using smartSchool.API.Data;
using smartSchool.API.Models;

namespace smartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetProfessores(true));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessoreById(id, false);

            if (professor == null) return BadRequest("O Professor não encontrado.");

            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (!_repo.SaveChanges()) return BadRequest("Professor não cadastrado.");

            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var retornaProf = _repo.GetProfessoreById(id, false);
            if (retornaProf == null) return BadRequest("O Professor não foi encontrado.");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Erro ao atualizar professor.");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var retornaProf = _repo.GetProfessoreById(id, false);
            if (retornaProf == null) return BadRequest("O Professor não encontrado.");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Erro ao atualizar professor.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = _repo.GetProfessoreById(id, false);
            if (professor == null) return BadRequest("O Professor não foi encontrado.");

            _repo.Delete(professor);
            if (_repo.SaveChanges())
                return Ok("Professor deletado.");

            return BadRequest("Erro ao deletar Professor.");
        }
    }
}