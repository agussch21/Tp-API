<<<<<<< HEAD
namespace TurnosMedicosAPI.DTOs
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Especialidad { get; set; }
        public string NombrePaciente { get; set; }
    }

    public class TurnoCreateDTO
    {
        public DateTime FechaHora { get; set; }
        public string Especialidad { get; set; }
        public int PacienteId { get; set; }
    }
}
=======
namespace TurnosMedicosAPI.DTOs
{
    public class TurnoDTO
    {
        public DateTime FechaHora { get; set; }
        public string Especialidad { get; set; }
        public int PacienteId { get; set; }
    }
}
>>>>>>> e7fffa95f9c76085a333b5e4e2b89ab73e2da12b
