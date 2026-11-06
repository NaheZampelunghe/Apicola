using Apicola.Application.DTOs.Duenio;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class DuenioMappingProfile : Profile
    {
        public DuenioMappingProfile()
        {
            CreateMap<Duenio, DuenioResponseDto>()
                .ForMember(dest => dest.Localidad, opt => opt.MapFrom(src => src.Localidad.Nombre));
            CreateMap<DuenioRequestDto, Duenio>();
            CreateMap<Duenio, DuenioSelectListDto>().ForMember(dest=>dest.Nombre,opt=>opt.MapFrom(src=>src.Nombre+ " " + src.Apellido));
        }
    }
}