using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using smartSchool.API.Data;
using smartSchool.API.DTOs;
using smartSchool.API.Models;
using System.Collections.Generic;

namespace smartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper map)
        {
            _repo = repo;
            _mapper = map;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, true);

            if (aluno == null) return BadRequest("O Aluno não encontrado.");

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
            var retornaAluno = _repo.GetAlunoById(id, false);
            if (retornaAluno == null) return BadRequest("O Aluno não encontrado.");

            _repo.Update(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não atualizado.");

            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var retornaAluno = _repo.GetAlunoById(id, false);
            if (retornaAluno == null) return BadRequest("O Aluno não encontrado.");

            _repo.Update(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não atualizado.");

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não encontrado.");

            _repo.Delete(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não Deletado.");

            return Ok("Aluno deletado.");
        }
    }
}