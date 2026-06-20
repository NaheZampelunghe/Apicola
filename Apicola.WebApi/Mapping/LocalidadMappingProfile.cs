using Apicola.Application.DTOs.Localidad;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class LocalidadMappingProfile : Profile
    {
        public LocalidadMappingProfile()
        {
            CreateMap<Localidad, LocalidadResponseDto>();
            CreateMap<LocalidadRequestDto, Localidad>();
        }
    }
}