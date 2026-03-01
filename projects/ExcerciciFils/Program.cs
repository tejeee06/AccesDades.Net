using System;
using System.Threading;
using ExcerciciFils.Services;

namespace ExcerciciFils;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Inici fil principal");

        // Instanciamos los servicios
        ICronometre c1 = new Cronometre("c1", 5);
        ICronometre c2 = new Cronometre("c2", 10);
        ICronometre c3 = new Cronometre("c3", 15);
        ICronometre c4 = new Cronometre("c4", 7);

        Thread t1 = new Thread(c1.Executar);
        Thread t2 = new Thread(c2.Executar);
        Thread t3 = new Thread(c3.Executar);
        Thread t4 = new Thread(c4.Executar);

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();

        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();

        Console.WriteLine("Final fil principal");
    }
}