namespace TasquesParaleles;

public class Immoble 
{
    private int id;
    private string adreca;
    private string tipus;
    private double llogatMensual;
    private double percentatgeIRPF;
    private double percentatgeDespeses;
    private double ingresNet;

    public Immoble(int id, string adreca, string tipus,double llogatMensual, double irpf, double despeses) 
    {
        this.id = id;
        this.adreca = adreca;
        this.tipus = tipus;
        this.llogatMensual = llogatMensual;
        this.percentatgeIRPF = irpf;
        this.percentatgeDespeses = despeses;
    }

    public void CalcularIngresNet() 
    {
        double deduccioIRPF = llogatMensual * percentatgeIRPF / 100.0;
        double deduccioDespeses = llogatMensual * percentatgeDespeses / 100.0;
        this.ingresNet = llogatMensual - deduccioIRPF - deduccioDespeses;
    }

    public double GetIngresNet() 
    {
        return ingresNet;
    }

    public override string ToString() 
    {
        return $"{id}-{adreca}[{tipus}]/Net:{ingresNet}";
    }
}