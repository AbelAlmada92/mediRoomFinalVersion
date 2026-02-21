using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacientesService _service;
        public PacientesController(IPacientesService service) => _service = service;

        // GET /api/pacientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        // GET /api/pacientes/legajo/123
        [HttpGet("legajo/{nLegajo:int}")]
        public async Task<IActionResult> GetByNLegajo(int nLegajo)
        {
            var paciente = await _service.GetByNLegajoAsync(nLegajo);
            return paciente is null ? NotFound() : Ok(paciente);
        }
    }
}