using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesService _service;
        public PacientesController(IPacientesService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("legajo/{nLegajo:int}")]
        public async Task<IActionResult> GetByIdPaciente(int nLegajo)
        {
            var paciente = await _service.GetByIdPacienteAsync(nLegajo);
            return paciente is null ? NotFound() : Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Paciente paciente)
        {
            if (paciente is null) return BadRequest();

            paciente.IdPaciente = 0;

            var created = await _service.CreateAsync(paciente);
            return CreatedAtAction(nameof(GetByIdPaciente), new { nLegajo = created.NLegajo }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Paciente paciente)
        {
            if (paciente is null) return BadRequest();

            if (paciente.IdPaciente != 0 && paciente.IdPaciente != id)
                return BadRequest("IdPaciente del body no coincide con el id de la URL.");

            var updated = await _service.UpdateAsync(id, paciente);
            return updated is null ? NotFound() : NoContent();
        }
    }
}