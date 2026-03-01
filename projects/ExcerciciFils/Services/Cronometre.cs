using System;
using System.Threading;
using ExcerciciFils.Models;

namespace ExcerciciFils.Services;

public class Cronometre : ICronometre
{
    private string nom;
    private int limit;

    public Cronometre(string nom, int limit)
    {
        this.nom = nom;
        this.limit = limit;
    }

    public void Executar()
    {
        Console.WriteLine($"{nom} - Abans");
        Comptar();
        Console.WriteLine($"{nom} - Després");
    }

    private void Comptar()
    {
        int segonActual = 0;
        
        while (segonActual <= limit)
        {
            EventJoc eventJoc = new EventJoc(100, 100, 50); 
            
            Console.WriteLine($"{nom}: segon {segonActual} | Generat {eventJoc}");

            try
            {
                Thread.Sleep(1000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.Error.WriteLine(e.Message);
            }
            
            segonActual++;
        }
    }
}