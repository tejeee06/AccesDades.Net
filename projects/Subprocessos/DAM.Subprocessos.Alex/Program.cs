using System;
using System.Diagnostics;
using System.IO;

namespace DAM.Subprocessos.Alex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Execució d'un subprocés per crear un arxiu ===\n");

            Console.Write("Introdueix el contingut a guardar: ");
            string content = Console.ReadLine() ?? "";

            Console.Write("Introdueix la ruta on guardar l'arxiu (ex: C:\\Temp): ");
            string route = Console.ReadLine() ?? "";

            Console.Write("Introdueix el nom de l'arxiu (ex: resultat.txt): ");
            string archiveName = Console.ReadLine() ?? "";

            string fullPath = Path.Combine(route, archiveName);

            ExecuteSubprocess(content, fullPath);

            Console.WriteLine("\nPrem qualsevol tecla per sortir...");
            Console.ReadKey();
        }

        static void ExecuteSubprocess(string content, string fullPath)
        {
            try
            {
                string arguments = $"/c echo {content} > \"{fullPath}\"";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process? process = Process.Start(startInfo)) 
                {
                    if (process == null)
                    {
                        Console.WriteLine("\n[ERROR] No s'ha pogut iniciar el procés del sistema.");
                        return;
                    }

                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine($"\n[SUBPROCÉS FINALITZAT] Èxit. Codi de retorn: {process.ExitCode}");
                        Console.WriteLine($"L'arxiu s'hauria d'haver creat a: {fullPath}");
                    }
                    else
                    {
                        Console.WriteLine($"\n[ERROR] El subprocés ha fallat amb codi: {process.ExitCode}");
                        Console.WriteLine($"Detall: {errors}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[EXCEPCIÓ] Error a l'executar el subprocés: {ex.Message}");
            }
        }
    }
}