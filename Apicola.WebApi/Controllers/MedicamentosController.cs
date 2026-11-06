using Apicola.Application;
using Apicola.Application.DTOs.Colmenar;
using Apicola.Application.DTOs.Medicamento;
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
    public class MedicamentosController : ControllerBase
    {
        private readonly ILogger<MedicamentosController> _logger;
        private readonly IApplication<Medicamento> _medicamento;
        private readonly IMapper _mapper;

        public MedicamentosController(
            ILogger<MedicamentosController> logger
            , IApplication<Medicamento> medicamento
            , IMapper mapper)
        {
            _logger = logger;
            _medicamento = medicamento;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<MedicamentoResponseDto>>(_medicamento.GetAll()));
        }

        [Route("SelectList")]
        [HttpGet]
        public ActionResult<IEnumerable<MedicamentoSelectListDto>> GetSelectList()
        {
            try
            {
                var list = _mapper.Map<IList<MedicamentoSelectListDto>>(_medicamento.GetAll().ToList());
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

            Medicamento medicamento = _medicamento.GetById(Id.Value);
            if (medicamento is null)
                return NotFound();

            return Ok(_mapper.Map<MedicamentoResponseDto>(medicamento));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MedicamentoRequestDto medicamentoRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var medicamento = _mapper.Map<Medicamento>(medicamentoRequestDto);
            _medicamento.Save(medicamento);
            return Ok(medicamento.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, MedicamentoRequestDto medicamentoRequestDto)
        {
            if (!Id.HasValue)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            Medicamento medicamentoBack = _medicamento.GetById(Id.Value);
            if (medicamentoBack is null)
                return NotFound();

            medicamentoBack = _mapper.Map<Medicamento>(medicamentoRequestDto);
            _medicamento.Save(medicamentoBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
                return BadRequest();

            Medicamento medicamentoBack = _medicamento.GetById(Id.Value);
            if (medicamentoBack is null)
                return NotFound();

            _medicamento.Delete(medicamentoBack.Id);
            return Ok();
        }
    }
}