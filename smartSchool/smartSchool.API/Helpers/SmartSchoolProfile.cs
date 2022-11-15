using AutoMapper;
using smartSchool.API.DTOs;
using smartSchool.API.Models;

namespace smartSchool.API.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(aluno => $"{aluno.Nome} {aluno.Sobrenome}"));
        }
    }
}