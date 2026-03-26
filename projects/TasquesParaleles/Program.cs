using TasquesParaleles;

namespace TasquesParaleles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CalculLloguerEnParalelSenseRetorn.Executar();
            await CalculLloguerEnParalelAmbRetorn.Executar();
        }
    }
}
