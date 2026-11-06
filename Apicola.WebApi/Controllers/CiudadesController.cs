using Apicola.Application;
using Apicola.Application.DTOs.Ciudad;
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
    public class CiudadesController : ControllerBase
    {
        private readonly ILogger<CiudadesController> _logger;
        private readonly IApplication<Ciudad> _ciudad;
        private readonly IMapper _mapper;

        public CiudadesController(
            ILogger<CiudadesController> logger
            , IApplication<Ciudad> ciudad
            , IMapper mapper)
        {
            _logger = logger;
            _ciudad = ciudad;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<CiudadResponseDto>>(_ciudad.GetAll()));
        }

        [Route("SelectList")]
        [HttpGet]
        public ActionResult<IEnumerable<CiudadSelectListDto>> GetSelectList()
        {
            try
            {
                var list = _mapper.Map<IList<CiudadSelectListDto>>(_ciudad.GetAll().ToList());
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

            Ciudad ciudad = _ciudad.GetById(Id.Value);
            if (ciudad is null)
                return NotFound();

            return Ok(_mapper.Map<CiudadResponseDto>(ciudad));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(CiudadRequestDto ciudadRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ciudad = _mapper.Map<Ciudad>(ciudadRequestDto);
            _ciudad.Save(ciudad);
            return Ok(ciudad.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, CiudadRequestDto ciudadRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Ciudad ciudadBack = _ciudad.GetById(Id.Value);
            if (ciudadBack is null)
                return NotFound();

            ciudadBack = _mapper.Map<Ciudad>(ciudadRequestDto);
            _ciudad.Save(ciudadBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Ciudad ciudadBack = _ciudad.GetById(Id.Value);
            if (ciudadBack is null)
                return NotFound();

            _ciudad.Delete(ciudadBack.Id);
            return Ok();
        }
    }
}