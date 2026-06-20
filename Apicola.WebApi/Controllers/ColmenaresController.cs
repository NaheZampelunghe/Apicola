using Apicola.Application;
using Apicola.Application.DTOs.Colmenar;
using Apicola.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Apicola.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColmenaresController : ControllerBase
    {
        private readonly ILogger<ColmenaresController> _logger;
        private readonly IApplication<Colmenar> _colmenar;
        private readonly IMapper _mapper;

        public ColmenaresController(
            ILogger<ColmenaresController> logger
            , IApplication<Colmenar> colmenar
            , IMapper mapper)
        {
            _logger = logger;
            _colmenar = colmenar;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ColmenarResponseDto>>(_colmenar.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Colmenar colmenar = _colmenar.GetById(Id.Value);
            if (colmenar is null)
                return NotFound();

            return Ok(_mapper.Map<ColmenarResponseDto>(colmenar));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ColmenarRequestDto colmenarRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var colmenar = _mapper.Map<Colmenar>(colmenarRequestDto);
            _colmenar.Save(colmenar);
            return Ok(colmenar.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ColmenarRequestDto colmenarRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Colmenar colmenarBack = _colmenar.GetById(Id.Value);
            if (colmenarBack is null)
                return NotFound();

            colmenarBack = _mapper.Map<Colmenar>(colmenarRequestDto);
            _colmenar.Save(colmenarBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Colmenar colmenarBack = _colmenar.GetById(Id.Value);
            if (colmenarBack is null)
                return NotFound();

            _colmenar.Delete(colmenarBack.Id);
            return Ok();
        }
    }
}