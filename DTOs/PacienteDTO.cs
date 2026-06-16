namespace TurnosMedicosAPI.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string ObraSocial { get; set; }
    }

    public class PacienteCreateDTO
    {
        public string NombreCompleto { get; set; }
        public string DNI { get; set; }
        public string ObraSocial { get; set; }
    }
}