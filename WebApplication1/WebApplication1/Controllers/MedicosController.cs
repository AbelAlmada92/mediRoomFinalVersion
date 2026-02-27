using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicosService _service;

        public MedicosController(IMedicosService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdMedico(int id)
        {
            var medico = await _service.GetByIdAsync(id);
            return medico is null ? NotFound() : Ok(medico);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Medico medico)
        {
            if (medico is null) return BadRequest();

            medico.IdMedico = 0;

            var created = await _service.CreateAsync(medico);
            return CreatedAtAction(nameof(GetByIdMedico), new { id = created.IdMedico }, created);


        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Medico medico)
        {
            if (medico is null) return BadRequest();

            var updated = await _service.UpdateAsync(id, medico);
            return updated is null ? NotFound() : NoContent();
        }


    }
}