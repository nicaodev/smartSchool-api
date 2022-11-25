using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using smartSchool.API.Data;
using smartSchool.API.Models;
using System.Threading.Tasks;

namespace smartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok( await _repo.GetProfessoresAsync(true));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var professor = await _repo.GetProfessoreByIdAsync(id, true);

            if (professor == null) return BadRequest("O Professor não encontrado.");

            return Ok(professor);
        } 
        
        [HttpGet("byAluno/{alunoId}")]
        public async Task<IActionResult> GetByAlunoId(int alunoId)
        {
            var professor = await _repo.GetProfessoreByAlunoIdAsync(alunoId, true);

            if (professor == null) return BadRequest("O Professor não encontrado.");

            return Ok(professor);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Professor professor)
        {
            _repo.Add(professor);
            if (!_repo.SaveChanges()) return BadRequest("Professor não cadastrado.");

            return Ok(professor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Professor professor)
        {
            var retornaProf = await _repo.GetProfessoreByIdAsync(id, false);
            if (retornaProf == null) return BadRequest("O Professor não foi encontrado.");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Erro ao atualizar professor.");
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, Professor professor)
        {
            var retornaProf = await _repo.GetProfessoreByIdAsync(id, false);
            if (retornaProf == null) return BadRequest("O Professor não encontrado.");

            _repo.Update(professor);
            if (_repo.SaveChanges())
                return Ok(professor);

            return BadRequest("Erro ao atualizar professor.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var professor = await _repo.GetProfessoreByIdAsync(id, false);
            if (professor == null) return BadRequest("O Professor não foi encontrado.");

            _repo.Delete(professor);
            if (_repo.SaveChanges())
                return Ok("Professor deletado.");

            return BadRequest("Erro ao deletar Professor.");
        }
    }
}