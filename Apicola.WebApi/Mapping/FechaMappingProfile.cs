using Apicola.Application.DTOs.Fecha;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class FechaMappingProfile : Profile
    {
        public FechaMappingProfile()
        {
            CreateMap<Fecha, FechaResponseDto>();
            CreateMap<FechaRequestDto, Fecha>();
        }
    }
}