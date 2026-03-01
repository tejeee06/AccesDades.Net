using GestioVisites.Application.DTOs;
using GestioVisites.Application.Services;

namespace GestioVisites.Presentation.Controllers
{
    public class VisitaMedicaController
    {
        private readonly VisitaMedicaService _service;

        public VisitaMedicaController(VisitaMedicaService service)
        {
            _service = service;
        }

        public bool MostrarMenu()
        {
            Console.WriteLine("\n--- Menu de gestió de visites mèdiques ---");
            Console.WriteLine("1. Afegir visita");
            Console.WriteLine("2. Llistar visites");
            Console.WriteLine("3. Actualitzar visita");
            Console.WriteLine("4. Eliminar visita");
            Console.WriteLine("5. Sortir");
            Console.WriteLine("Escolleix una opció:");

            var opcio = Console.ReadLine();
            try
            {
                switch (opcio)
                {
                    case "1":
                        Console.WriteLine("Introdueix el nom del pacient: ");
                        string pacient = Console.ReadLine() ?? "";
                        Console.WriteLine("Introdueix el nom del metge: ");
                        string metge = Console.ReadLine() ?? "";

                        _service.RegistrarVisita(new VisitaMedicaDTO
                        {
                            NomPacient = pacient,
                            NomMetge = metge,
                            DataVisita = DateTime.Now,
                            Diagnostic = "Sense diagnòstic"
                        });
                        Console.WriteLine("Visita registrada correctament.");

                        break;

                    case "2":
                        var visites = _service.ObtenirVisites();
                        Console.WriteLine("\n-- LListat de visites --");
                        if (!visites.Any())
                        {
                            Console.WriteLine("No hi ha visites registrades.");
                        }
                        else
                        {
                            foreach (var v in visites)
                            {
                                Console.WriteLine($"[ID: {v.Id}] {v.DataVisita.ToShortDateString()} | Pacient: {v.NomPacient} | Metge: {v.NomMetge} | Diagnsotic: {v.Diagnostic}");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Introdueix el ID de la visita a actualitzar: ");
                        if (int.TryParse(Console.ReadLine(), out int idActualitzar))
                        {
                            var visitaExistent = _service.ObtenirVisitaPerId(idActualitzar);
                            if (visitaExistent != null)
                            {
                                Console.Write($"Nou diagnostic (Actual: {visitaExistent.Diagnostic}): ");
                                string nouDiagnostic = Console.ReadLine() ?? "";
                                visitaExistent.Diagnostic = nouDiagnostic;
                                
                                _service.ActualitzarVisita(visitaExistent);
                                Console.WriteLine("Visita actualitzada correctament.");
                            }
                            else
                            {
                                Console.WriteLine("No s'ha trobat cap visita amb aquest ID.");
                            }
                        }
                        else { Console.WriteLine("ID invàlid. Has d'introduir un número."); }
                        break;

                    case "4":
                        Console.Write("Introdueix el ID de la visita a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out int idEliminar))
                        {
                            var visitaEliminar = _service.ObtenirVisitaPerId(idEliminar);
                            if(visitaEliminar != null)
                            {
                                _service.EliminarVisita(idEliminar);
                                Console.WriteLine("Visita eliminada correctament.");
                            }
                            else
                            {
                                Console.WriteLine("No s'ha trobat cap visita amb aquest ID per eliminar.");
                            }
                        }
                        else { Console.WriteLine("ID invàlid. Has d'introduir un número."); }
                        break;
                    
                    case "5":
                        Console.WriteLine("Sortint del programa... Fins la propera!");
                        return false; 
                    
                    default:
                        Console.WriteLine("Opció no reconeguda. Si us plau, tria un número del 1 al 5.");
                        break;   
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n[ERROR INESPERAT]: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Per favor, verifica la teva connexió a la base de dades o contacta amb l'administrador.");
            }

            return true;
        }
    }
}