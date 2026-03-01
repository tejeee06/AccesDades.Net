using GestioVisites.Application.Services;
using GestioVisites.Domain.Interfaces;
using GestioVisites.Infraestructure.Repositories;
using GestioVisites.Presentation.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace GestioVisites.Presentation
{
    class Program
    {
        static void Main(string[]args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IVisitaMedicaRepository, VisitaMedicaRepository>() 
                .AddScoped<VisitaMedicaService>()
                .AddScoped<VisitaMedicaController>()
                .BuildServiceProvider();
            
            var controller = serviceProvider.GetService<VisitaMedicaController>();
            bool continuar = true;

            while (continuar)
            {
                continuar = controller?.MostrarMenu() ?? false;
            }
        }
    }
}