namespace VisitesMediques.Domain;

public class VisitaMedica
{
    public int IdVisita { get; set; }
    public string NomPacient { get; set; } = string.Empty;
    public string NomMetge { get; set; } = string.Empty;
    public DateOnly Data { get; set; }
    public string Diagnostic { get; set; } = string.Empty;
}