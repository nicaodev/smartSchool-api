using AutoMapper;
using smartSchool.API.DTOs;
using smartSchool.API.Models;

namespace smartSchool.API.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(aluno => $"{aluno.Nome} {aluno.Sobrenome}")
                )
                .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(idade => idade.DataNasc.IdadeAtual())
                );

            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoCadastroDto>().ReverseMap();
        }
    }
}