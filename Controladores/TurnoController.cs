using Microsoft.AspNetCore.Mvc;
using TurnosMedicosAPI.DTOs;
using TurnosMedicosAPI.Services;

namespace TurnosMedicosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnoController : ControllerBase
    {
        private readonly TurnoService _service;

        public TurnoController(TurnoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ObtenerTodos());
        }

        [HttpPost]
        public async Task<IActionResult> Post(TurnoDTO dto)
        {
            await _service.Crear(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TurnoDTO dto)
        {
            await _service.Actualizar(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Eliminar(id);
            return NoContent();
        }
    }
}
