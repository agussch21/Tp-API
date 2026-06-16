using Microsoft.EntityFrameworkCore;
using TurnosMedicosAPI.Models;

namespace TurnosMedicosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Turno> Turnos { get; set; }
    }
}
