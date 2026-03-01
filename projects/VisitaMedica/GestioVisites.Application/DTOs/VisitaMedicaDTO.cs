namespace GestioVisites.Application.DTOs
{
    public class VisitaMedicaDTO
    {
        public int Id { get; set; }
        public string NomPacient { get; set; } = string.Empty;
        public string NomMetge { get; set; } = string.Empty;
        public DateTime DataVisita { get; set; }
        public string? Diagnostic { get; set; }
    }
}