using Apicola.Application;
using Apicola.Application.DTOs.Colmena;
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
    public class ColmenasController : ControllerBase
    {
        private readonly ILogger<ColmenasController> _logger;
        private readonly IApplication<Colmena> _colmena;
        private readonly IMapper _mapper;

        public ColmenasController(
            ILogger<ColmenasController> logger
            , IApplication<Colmena> colmena
            , IMapper mapper)
        {
            _logger = logger;
            _colmena = colmena;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ColmenaResponseDto>>(_colmena.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Colmena colmena = _colmena.GetById(Id.Value);
            if (colmena is null)
                return NotFound();

            return Ok(_mapper.Map<ColmenaResponseDto>(colmena));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ColmenaRequestDto colmenaRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var colmena = _mapper.Map<Colmena>(colmenaRequestDto);
            _colmena.Save(colmena);
            return Ok(colmena.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ColmenaRequestDto colmenaRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Colmena colmenaBack = _colmena.GetById(Id.Value);
            if (colmenaBack is null)
                return NotFound();

            colmenaBack = _mapper.Map<Colmena>(colmenaRequestDto);
            _colmena.Save(colmenaBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Colmena colmenaBack = _colmena.GetById(Id.Value);
            if (colmenaBack is null)
                return NotFound();

            _colmena.Delete(colmenaBack.Id);
            return Ok();
        }
    }
}