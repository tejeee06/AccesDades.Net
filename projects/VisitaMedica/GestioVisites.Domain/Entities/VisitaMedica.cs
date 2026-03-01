namespace GestioVisites.Domain.Entities
{
    public class VisitaMedica
    {
        public int PK_VisitaMedicaID { get; set; }
        public string NomPacient { get; set; } = string.Empty;
        public string NomMetge { get; set; } = string.Empty;
        public DateTime DataVisita { get; set; }
        public string? Diagnostic { get; set; }
    }
}