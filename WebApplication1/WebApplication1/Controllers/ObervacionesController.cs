using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObservacionesController : ControllerBase
    {
        private readonly IObservacionesService _service;
        public ObservacionesController(IObservacionesService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("paciente/{idPaciente:int}")]
        public async Task<IActionResult> GetByPacienteId(int idPaciente)
            => Ok(await _service.GetByPacienteIdAsync(idPaciente));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var obs = await _service.GetByIdAsync(id);
            return obs is null ? NotFound() : Ok(obs);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Observacion observacion)
        {
            if (observacion is null) return BadRequest();

            if (observacion.IdObservacion != 0 && observacion.IdObservacion != id)
                return BadRequest("IdObservacion del body no coincide con el id de la URL.");

            var updated = await _service.UpdateAsync(id, observacion);
            return updated is null ? NotFound() : NoContent();
        }
    }
}