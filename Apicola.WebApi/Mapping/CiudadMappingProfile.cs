using Apicola.Application.DTOs.Ciudad;
using Apicola.Application.DTOs.Colmenar;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class CiudadMappingProfile : Profile
    {
        public CiudadMappingProfile()
        {
            CreateMap<Ciudad, CiudadResponseDto>()
                .ForMember(dest => dest.Provincia, opt => opt.MapFrom(src => src.Provincia.Nombre))
                .ForMember(dest => dest.IdProvincia, opt => opt.MapFrom(src => src.Provincia.Id));
            CreateMap<CiudadRequestDto, Ciudad>();
            CreateMap<Ciudad, CiudadSelectListDto>();

        }
    }
}