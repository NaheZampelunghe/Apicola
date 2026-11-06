using Apicola.Application.DTOs.Ubicacion;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class UbicacionMappingProfile : Profile
    {
        public UbicacionMappingProfile()
        {
            CreateMap<Ubicacion, UbicacionResponseDto>().
                ForMember(dest=>dest.Localidad,opt=>opt.MapFrom(src=>src.Localidad.Nombre));
            CreateMap<UbicacionRequestDto, Ubicacion>();
            CreateMap<Ubicacion, UbicacionSelectListDto>();
        }
    }
}