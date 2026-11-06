using Apicola.Application;
using Apicola.Application.DTOs.CuradoAlimentado;
using Apicola.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Apicola.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialColmenarController : ControllerBase
    {
        private readonly ILogger<HistorialColmenarController> _logger;
        private readonly IApplication<HistorialColmenar> _historialColmenar;
        private readonly IMapper _mapper;

        public HistorialColmenarController(
            ILogger<HistorialColmenarController> logger
            , IApplication<HistorialColmenar> historialColmenar
            , IMapper mapper)
        {
            _logger = logger;
            _historialColmenar = historialColmenar;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<HistorialColmenarResponseDto>>(_historialColmenar.GetAll().OrderByDescending(h=>h.FechaVisita).
                                                                                        ThenByDescending(h=>h.Id)));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            HistorialColmenar historialColmenar = _historialColmenar.GetById(Id.Value);
            if (historialColmenar is null)
                return NotFound();

            return Ok(_mapper.Map<HistorialColmenarResponseDto>(historialColmenar));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(HistorialColmenarRequestDto historialColmenarRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var historialColmenar = _mapper.Map<HistorialColmenar>(historialColmenarRequestDto);
            _historialColmenar.Save(historialColmenar);
            return Ok(historialColmenar.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, HistorialColmenarRequestDto historialColmenarRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            HistorialColmenar historialColmenarBack = _historialColmenar.GetById(Id.Value);
            if (historialColmenarBack is null)
                return NotFound();

            historialColmenarBack = _mapper.Map<HistorialColmenar>(historialColmenarRequestDto);
            _historialColmenar.Save(historialColmenarBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            HistorialColmenar historialColmenarBack = _historialColmenar.GetById(Id.Value);
            if (historialColmenarBack is null)
                return NotFound();

            _historialColmenar.Delete(historialColmenarBack.Id);
            return Ok();
        }
    }
}