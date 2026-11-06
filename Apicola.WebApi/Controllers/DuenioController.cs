using Apicola.Application;
using Apicola.Application.DTOs.Duenio;
using Apicola.Application.DTOs.Provincia;
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
    public class DueniosController : ControllerBase
    {
        private readonly ILogger<DueniosController> _logger;
        private readonly IApplication<Duenio> _duenio;
        private readonly IMapper _mapper;

        public DueniosController(
            ILogger<DueniosController> logger
            , IApplication<Duenio> duenio
            , IMapper mapper)
        {
            _logger = logger;
            _duenio = duenio;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<DuenioResponseDto>>(_duenio.GetAll()));
        }

        [Route("SelectList")]
        [HttpGet]
        public ActionResult<IEnumerable<DuenioSelectListDto>> GetSelectList()
        {
            try
            {
                var list = _mapper.Map<IList<DuenioSelectListDto>>(_duenio.GetAll().ToList());
                return Ok(list);
            }
            catch (Exception ex)
            {
                return Conflict();
            }
        }


        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Duenio duenio = _duenio.GetById(Id.Value);
            if (duenio is null)
                return NotFound();

            return Ok(_mapper.Map<DuenioResponseDto>(duenio));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(DuenioRequestDto duenioRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var duenio = _mapper.Map<Duenio>(duenioRequestDto);
            _duenio.Save(duenio);
            return Ok(duenio.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, DuenioRequestDto duenioRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Duenio duenioBack = _duenio.GetById(Id.Value);
            if (duenioBack is null)
                return NotFound();

            duenioBack = _mapper.Map<Duenio>(duenioRequestDto);
            _duenio.Save(duenioBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Duenio duenioBack = _duenio.GetById(Id.Value);
            if (duenioBack is null)
                return NotFound();

            _duenio.Delete(duenioBack.Id);
            return Ok();
        }
    }
}