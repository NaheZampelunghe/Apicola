using Apicola.Application.DTOs.Ciudad;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class CiudadMappingProfile : Profile
    {
        public CiudadMappingProfile()
        {
            CreateMap<Ciudad, CiudadResponseDto>()
                .ForMember(dest => dest.Provincia, opt => opt.MapFrom(src => src.Provincia.Nombre));
            CreateMap<CiudadRequestDto, Ciudad>();
        }
    }
}