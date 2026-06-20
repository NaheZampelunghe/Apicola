using Apicola.Application;
using Apicola.Application.DTOs.Provincia;
using Apicola.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apicola.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly ILogger<ProvinciasController> _logger;
        private readonly IApplication<Provincia> _provincia;
        private readonly IMapper _mapper;

        public ProvinciasController(
            ILogger<ProvinciasController> logger
            , IApplication<Provincia> provincia
            , IMapper mapper)
        {
            _logger = logger;
            _provincia = provincia;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ProvinciaResponseDto>>(_provincia.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Provincia provincia = _provincia.GetById(Id.Value);
            if (provincia is null)
                return NotFound();

            return Ok(_mapper.Map<ProvinciaResponseDto>(provincia));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ProvinciaRequestDto provinciaRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var provincia = _mapper.Map<Provincia>(provinciaRequestDto);
            _provincia.Save(provincia);
            return Ok(provincia.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ProvinciaRequestDto provinciaRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Provincia provinciaBack = _provincia.GetById(Id.Value);
            if (provinciaBack is null)
                return NotFound();

            provinciaBack = _mapper.Map<Provincia>(provinciaRequestDto);
            _provincia.Save(provinciaBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Provincia provinciaBack = _provincia.GetById(Id.Value);
            if (provinciaBack is null)
                return NotFound();

            _provincia.Delete(provinciaBack.Id);
            return Ok();
        }
    }
}
