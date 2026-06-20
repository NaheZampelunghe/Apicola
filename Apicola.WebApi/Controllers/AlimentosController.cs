using Apicola.Application;
using Apicola.Application.DTOs.Alimento;
using Apicola.Entities;
using Apicola.Entities.MicrosoftIdentity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Apicola.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {
        private readonly ILogger<AlimentosController> _logger;
        private readonly IApplication<Alimento> _alimento;
        private readonly IMapper _mapper;
        public AlimentosController(
            ILogger<AlimentosController> logger
            , IApplication<Alimento> alimento
            , IMapper mapper)
        {
            _logger = logger;
            _alimento = alimento;
            _mapper = mapper;
        }
        // GET: api/<AlimentosController>
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {

            return Ok(_mapper.Map<IList<AlimentoResponseDto>>(_alimento.GetAll()));

        }
        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Alimento alimento = _alimento.GetById(Id.Value);
            if (alimento is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AlimentoResponseDto>(alimento));
        }

        // POST api/<AlimentosController>
        [HttpPost]
        public async Task<IActionResult> Crear(AlimentoRequestDto alimentoRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var alimento = _mapper.Map<Alimento>(alimentoRequestDto);
            _alimento.Save(alimento);
            return Ok(alimento.Id);
        }

        // PUT api/<AlimentosController>/5
        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, AlimentoRequestDto alimentoRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Alimento alimentoBack = _alimento.GetById(Id.Value);
            if (alimentoBack is null)
            { return NotFound(); }
            alimentoBack = _mapper.Map<Alimento>(alimentoRequestDto);
            _alimento.Save(alimentoBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Alimento alimentoBack = _alimento.GetById(Id.Value);
            if (alimentoBack is null)
            { return NotFound(); }
            _alimento.Delete(alimentoBack.Id);
            return Ok();
        }
    }
}
