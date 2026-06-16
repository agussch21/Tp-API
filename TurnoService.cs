using Microsoft.EntityFrameworkCore;
using TurnosMedicosAPI.Data;
using TurnosMedicosAPI.DTOs;
using TurnosMedicosAPI.Models;

namespace TurnosMedicosAPI.Services
{
    public class TurnoService
    {
        private readonly AppDbContext _context;

        public TurnoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Turno>> ObtenerTodos()
        {
            return await _context.Turnos
                .Include(t => t.Paciente)
                .ToListAsync();
        }

        public async Task<Turno?> ObtenerPorId(int id)
        {
            return await _context.Turnos.FindAsync(id);
        }

        public async Task Crear(TurnoDTO dto)
        {
            var turno = new Turno
            {
                FechaHora = dto.FechaHora,
                Especialidad = dto.Especialidad,
                PacienteId = dto.PacienteId
            };

            _context.Turnos.Add(turno);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(int id, TurnoDTO dto)
        {
            var turno = await _context.Turnos.FindAsync(id);

            if (turno == null) return;

            turno.FechaHora = dto.FechaHora;
            turno.Especialidad = dto.Especialidad;
            turno.PacienteId = dto.PacienteId;

            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);

            if (turno == null) return;

            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
        }
    }
}
