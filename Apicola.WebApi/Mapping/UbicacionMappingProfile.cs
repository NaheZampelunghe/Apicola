using Apicola.Application.DTOs.Ubicacion;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class UbicacionMappingProfile : Profile
    {
        public UbicacionMappingProfile()
        {
            CreateMap<Ubicacion, UbicacionResponseDto>();
            CreateMap<UbicacionRequestDto, Ubicacion>();
        }
    }
}