using Apicola.Application.DTOs.Alimento;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class AlimentoMappingProfile : Profile
    {
        public AlimentoMappingProfile()
        {
            CreateMap<Alimento, AlimentoResponseDto>();
            CreateMap<Alimento, AlimentoSelectListDto>();
            CreateMap<AlimentoRequestDto, Alimento>();
        }
    }
}
