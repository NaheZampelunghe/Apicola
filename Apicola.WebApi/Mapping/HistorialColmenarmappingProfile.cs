using Apicola.Application.DTOs.CuradoAlimentado;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class HistorialColmenarmappingProfile : Profile
    {
        public HistorialColmenarmappingProfile()
        {
            CreateMap<HistorialColmenar, HistorialColmenarResponseDto>()
                .ForMember(dest => dest.Alimento, opt => opt.MapFrom(src => src.Alimento.Nombre))
                .ForMember(dest => dest.Medicamento, opt => opt.MapFrom(src => src.Medicamento.Nombre))
                .ForMember(dest => dest.Colmenar, opt => opt.MapFrom(src =>src.Colmenar.Ubicacion.Nombre+" "+ src.Colmenar.Nombre));
            CreateMap<HistorialColmenarRequestDto, HistorialColmenar>()
                .ForMember(dest => dest.IdAlimento, opt => opt.MapFrom(src => src.IdAlimento == 0 ? null : src.IdAlimento))
                .ForMember(dest => dest.IdMedicamento, opt => opt.MapFrom(src => src.IdMedicamento == 0 ? null : src.IdMedicamento))
                .ForMember(dest => dest.IdColmenar, opt => opt.MapFrom(src => src.IdColmenar == 0 ? null : src.IdColmenar));
        }
    }
}