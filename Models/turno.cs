namespace TurnosMedicosAPI.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Especialidad { get; set; }
        
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}