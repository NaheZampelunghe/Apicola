using Apicola.Application;
using Apicola.Application.DTOs.Fecha;
using Apicola.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apicola.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechasController : ControllerBase
    {
        private readonly ILogger<FechasController> _logger;
        private readonly IApplication<Fecha> _fecha;
        private readonly IMapper _mapper;

        public FechasController(
            ILogger<FechasController> logger
            , IApplication<Fecha> fecha
            , IMapper mapper)
        {
            _logger = logger;
            _fecha = fecha;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<FechaResponseDto>>(_fecha.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Fecha fecha = _fecha.GetById(Id.Value);
            if (fecha is null)
                return NotFound();

            return Ok(_mapper.Map<FechaResponseDto>(fecha));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(FechaRequestDto fechaRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var fecha = _mapper.Map<Fecha>(fechaRequestDto);
            _fecha.Save(fecha);
            return Ok(fecha.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, FechaRequestDto fechaRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Fecha fechaBack = _fecha.GetById(Id.Value);
            if (fechaBack is null)
                return NotFound();

            fechaBack = _mapper.Map<Fecha>(fechaRequestDto);
            _fecha.Save(fechaBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Fecha fechaBack = _fecha.GetById(Id.Value);
            if (fechaBack is null)
                return NotFound();

            _fecha.Delete(fechaBack.Id);
            return Ok();
        }
    }
}