namespace TurnosMedicosAPI.DTOs
{
    public class TurnoDTO
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Especialidad { get; set; }
        public int PacienteId { get; set; }
        public string NombrePaciente { get; set; }
    }
}
