using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TasquesParaleles;

public class CalculLloguerEnParalelSenseRetorn
{
    private static readonly List<Immoble> llistaCompartida = new();
    private static readonly object llistaLock = new();

    public static async Task Executar()
    {
        Console.WriteLine("=== Exemple 1: Task (sense retorn) ===");

        var immobles = new List<Immoble>
        {
            new Immoble(1, "Passeig de Catalunya 10", "Pis", 1000, 19, 5),
            new Immoble(2, "Carrer del Maresme 5", "Local", 2000, 19, 10),
            new Immoble(3, "Carre Ample 4", "Garatge", 150, 19, 2)
        };

        var tasques = new List<Task>();

        foreach (var imm in immobles)
        {
            tasques.Add(CalcularLloguerNetSenseRetorn(imm));
        }

        await Task.WhenAll(tasques);

        Console.WriteLine("\nLlista compartida:");
        lock (llistaLock)
        {
            foreach (var item in llistaCompartida)
            {
                Console.WriteLine(item.ToString());
            }
        }
        Console.WriteLine("Execució finalitzada.\n");
    }

    private static Task CalcularLloguerNetSenseRetorn(Immoble imm)
    {
        return Task.Run(() =>
        {
            imm.CalcularIngresNet();

            lock (llistaLock)
            {
                llistaCompartida.Add(imm);
            }
        });
    }
}