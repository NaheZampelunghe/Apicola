using Apicola.Application.DTOs.Localidad;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class LocalidadMappingProfile : Profile
    {
        public LocalidadMappingProfile()
        {
            CreateMap<Localidad, LocalidadResponseDto>().
                ForMember(dest=>dest.Ciudad,opt=>opt.MapFrom(src=>src.Ciudad.Nombre));
            CreateMap<LocalidadRequestDto, Localidad>();
            CreateMap<Localidad, LocalidadSelectListDto>();
        }
    }
}