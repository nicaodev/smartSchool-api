﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using smartSchool.API.Data;
using smartSchool.API.DTOs;
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
        public async Task<IActionResult> Get()
        {
            var alunos = await _repo.GetAlunosAsync(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
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

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

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