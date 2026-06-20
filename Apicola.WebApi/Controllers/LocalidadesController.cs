using Apicola.Application;
using Apicola.Application.DTOs.Localidad;
using Apicola.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apicola.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        private readonly ILogger<LocalidadesController> _logger;
        private readonly IApplication<Localidad> _localidad;
        private readonly IMapper _mapper;

        public LocalidadesController(
            ILogger<LocalidadesController> logger
            , IApplication<Localidad> localidad
            , IMapper mapper)
        {
            _logger = logger;
            _localidad = localidad;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<LocalidadResponseDto>>(_localidad.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Localidad localidad = _localidad.GetById(Id.Value);
            if (localidad is null)
                return NotFound();

            return Ok(_mapper.Map<LocalidadResponseDto>(localidad));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(LocalidadRequestDto localidadRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var localidad = _mapper.Map<Localidad>(localidadRequestDto);
            _localidad.Save(localidad);
            return Ok(localidad.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, LocalidadRequestDto localidadRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Localidad localidadBack = _localidad.GetById(Id.Value);
            if (localidadBack is null)
                return NotFound();

            localidadBack = _mapper.Map<Localidad>(localidadRequestDto);
            _localidad.Save(localidadBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Localidad localidadBack = _localidad.GetById(Id.Value);
            if (localidadBack is null)
                return NotFound();

            _localidad.Delete(localidadBack.Id);
            return Ok();
        }
    }
}