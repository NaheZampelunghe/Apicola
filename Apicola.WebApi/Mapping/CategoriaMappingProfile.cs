using Apicola.Application.DTOs.Categoria;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class CategoriaMappingProfile : Profile
    {
        public CategoriaMappingProfile()
        {
            CreateMap<Categoria, CategoriaResponseDto>();
            CreateMap<CategoriaRequestDto, Categoria>();
        }
    }
}
