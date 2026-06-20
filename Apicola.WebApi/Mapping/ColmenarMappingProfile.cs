using Apicola.Application.DTOs.Colmenar;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class ColmenarMappingProfile : Profile
    {
        public ColmenarMappingProfile()
        {
            CreateMap<Colmenar, ColmenarResponseDto>();
            CreateMap<ColmenarRequestDto, Colmenar>();
        }
    }
}