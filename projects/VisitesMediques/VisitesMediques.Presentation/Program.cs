using Microsoft.EntityFrameworkCore;
using VisitesMediques.Application;
using VisitesMediques.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<VisitesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IVisitaMedicaRepository, VisitaMedicaRepository>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();