using Microsoft.AspNetCore.Mvc;
using TurnosMedicosAPI.DTOs;
using TurnosMedicosAPI.Services;

namespace TurnosMedicosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _service;

        public PacienteController(PacienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.ObtenerTodos());
        }

        [HttpPost]
        public async Task<IActionResult> Post(PacienteDTO dto)
        {
            await _service.Crear(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PacienteDTO dto)
        {
            await _service.Actualizar(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Eliminar(id);
            return Ok();
        }
    }
}