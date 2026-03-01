using System;

namespace ExcerciciFils.Models;

public class EventJoc : IEventJoc
{
    private int midaProfunditatPantalla;
    public int X { get; private set; }
    public int Y { get; private set; }
    public int Z { get; private set; }

    public EventJoc(int maxWidth, int maxHeight, int midaProfunditatPantalla)
    {
        this.midaProfunditatPantalla = midaProfunditatPantalla;
        GenerarPosicioAleatoria(maxWidth, maxHeight);
    }

    public void GenerarPosicioAleatoria(int maxWidth, int maxHeight)
    {
        Random rnd = new Random();
        X = rnd.Next(0, maxWidth);
        Y = rnd.Next(0, maxHeight);
        Z = rnd.Next(0, midaProfunditatPantalla);
    }

    public override string ToString()
    {
        return $"[Posició 3D -> X:{X}, Y:{Y}, Z:{Z}]";
    }
}