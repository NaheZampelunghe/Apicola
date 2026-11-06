using Apicola.Application.DTOs.Colmenar;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class ColmenarMappingProfile : Profile
    {
        public ColmenarMappingProfile()
        {
            CreateMap<Colmenar, ColmenarResponseDto>().
                ForMember(dest=>dest.Ubicacion,opt=>opt.MapFrom(src=>src.Ubicacion.Nombre)).
                ForMember(dest=>dest.CantidadColmenas,opt=>opt.MapFrom(src=>src.Colmenas.Count()));
            CreateMap<Colmenar, ColmenarSelectListDto>().ForMember(dest=>dest.Nombre,opt=>opt.MapFrom(src=>src.Ubicacion.Nombre + " " + src.Nombre));
            CreateMap<ColmenarRequestDto, Colmenar>();
        }
    }
}