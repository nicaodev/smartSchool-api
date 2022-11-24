using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using smartSchool.API.Data;
using smartSchool.API.DTOs;
using smartSchool.API.Helpers;
using smartSchool.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace smartSchool.API.Controllers
{/// <summary>
///
/// </summary>
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

        /// <summary>
        /// Retorna todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            //http://localhost:41200/api/aluno?pageNumber=1&pageSize=4

            var alunos = await _repo.GetAlunosAsync(pageParams, true);

            var alunosDto = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

            Response.AddPagination(alunos.CurrentPage, alunos.PageSize, alunos.TotalCount, alunos.TotalPages);

            return Ok(alunosDto);
        }

        /// <summary>
        /// Método responsável por retornar apenas um único Aluno informando o ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var aluno = await _repo.GetAlunoByIdAsync(id, true);

            if (aluno == null) return BadRequest("O Aluno não encontrado.");

            var alunoDto = _mapper.Map<AlunoCadastroDto>(aluno);

            return Ok(alunoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlunoCadastroDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);
            _repo.Add(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não cadastrado.");

            return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, AlunoCadastroDto model)
        {
            var aluno = await _repo.GetAlunoByIdAsync(id, false);
            if (aluno == null) return BadRequest("O Aluno não encontrado.");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não atualizado.");

            return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, AlunoCadastroDto model)
        {
            var aluno = await _repo.GetAlunoByIdAsync(id, false);
            if (aluno == null) return BadRequest("O Aluno não encontrado.");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não atualizado.");

            return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
        }

        [HttpPatch("{id}/trocarEstado")]
        public async Task<IActionResult> trocarEstado(int id, TrocaEstadoDto trocaEstado)
        {
            var aluno = await _repo.GetAlunoByIdAsync(id, false);
            aluno.Ativo = trocaEstado.Estado;
            if (aluno == null) return BadRequest("O Aluno não encontrado.");



            _repo.Update(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não atualizado.");
            {
                var temp = aluno.Ativo ? "ativado" : "desativado";
                return Ok(new { message = $"Aluno {temp} com sucesso" });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _repo.GetAlunoByIdAsync(id, false);
            if (aluno == null) return BadRequest("O Aluno não encontrado.");

            _repo.Delete(aluno);
            if (!_repo.SaveChanges()) return BadRequest("Aluno não Deletado.");

            return Ok("Aluno deletado.");
        }
    }
}