using Apicola.Application.DTOs.Medicamento;
using Apicola.Entities;
using AutoMapper;

namespace Apicola.WebApi.Mapping
{
    public class MedicamentoMappingProfile : Profile
    {
        public MedicamentoMappingProfile()
        {
            CreateMap<Medicamento, MedicamentoResponseDto>();
            CreateMap<MedicamentoRequestDto, Medicamento>();
        }
    }
}