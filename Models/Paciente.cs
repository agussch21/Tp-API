namespace TurnosMedicosAPI.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string ObraSocial { get; set; }
        public List<Turno> Turnos { get; set; } = new List<Turno>();
    }
}