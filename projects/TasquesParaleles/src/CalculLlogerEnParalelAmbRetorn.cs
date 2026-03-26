using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TasquesParaleles;

public class CalculLloguerEnParalelAmbRetorn
{
    public static async Task Executar()
    {
        Console.WriteLine("=== Exemple 2: Task<T> (amb retorn) ===");

        var immobles = new List<Immoble>
        {
            new Immoble(4, "Carrer de Joaquim Ruyra 44", "Pis", 1200, 19, 6),
            new Immoble(5, "Passeig de la Marina 33", "Local", 3500, 19, 8)
        };

        var tasques = new List<Task<Immoble>>();

        foreach (var imm in immobles)
        {
            tasques.Add(CalcularLloguerNetAmbRetorn(imm));
        }

        var resultats = await Task.WhenAll(tasques);

        Console.WriteLine("\nResultats obtinguts:");
        foreach (var item in resultats)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine("Execució finalitzada.\n");
    }

    private static Task<Immoble> CalcularLloguerNetAmbRetorn(Immoble imm)
    {
        return Task.Run(() =>
        {
            imm.CalcularIngresNet();
            return imm; 
        });
    }
}