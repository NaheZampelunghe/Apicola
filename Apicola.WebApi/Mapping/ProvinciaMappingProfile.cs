using Apicola.Application.DTOs.Provincia;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class ProvinciaMappingProfile : Profile
    {
        public ProvinciaMappingProfile()
        {
            CreateMap<Provincia, ProvinciaResponseDto>();
            CreateMap<ProvinciaRequestDto, Provincia>();
            CreateMap<Provincia, ProvinciaSelectListDto>();
        }
    }
}
