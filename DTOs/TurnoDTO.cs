namespace TurnosMedicosAPI.DTOs
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        public string FechaHora { get; set; } // Cambiado de DateTime a string
        public string Especialidad { get; set; }
        public int PacienteId { get; set; }
        public string NombrePaciente { get; set; }
    }
}
