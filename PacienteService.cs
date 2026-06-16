using Microsoft.EntityFrameworkCore;
using TurnosMedicosAPI.Data;
using TurnosMedicosAPI.DTOs;
using TurnosMedicosAPI.Models;

namespace TurnosMedicosAPI.Services
{
    public class PacienteService
    {
        private readonly AppDbContext _context;

        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> ObtenerTodos()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente?> ObtenerPorId(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task Crear(PacienteDTO dto)
        {
            var paciente = new Paciente
            {
                NombreCompleto = dto.NombreCompleto,
                DNI = dto.DNI,
                ObraSocial = dto.ObraSocial
            };

            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Actualizar(int id, PacienteDTO dto)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null) return;

            paciente.NombreCompleto = dto.NombreCompleto;
            paciente.DNI = dto.DNI;
            paciente.ObraSocial = dto.ObraSocial;

            await _context.SaveChangesAsync();
        }

        public async Task Eliminar(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null) return;

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }
}
