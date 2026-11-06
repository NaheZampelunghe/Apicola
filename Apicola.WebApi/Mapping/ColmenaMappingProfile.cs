using Apicola.Application.DTOs.Colmena;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class ColmenaMappingProfile : Profile
    {
        public ColmenaMappingProfile()
        {
            CreateMap<Colmena, ColmenaResponseDto>()
                .ForMember(dest => dest.Colmenar, opt => opt.MapFrom(src =>src.Colmenar.Ubicacion.Nombre+" "+ src.Colmenar.Nombre))
                .ForMember(dest => dest.Duenio, opt => opt.MapFrom(src => src.Duenio.Nombre + " " + src.Duenio.Apellido));
            CreateMap<ColmenaRequestDto, Colmena>();
        }
    }
}