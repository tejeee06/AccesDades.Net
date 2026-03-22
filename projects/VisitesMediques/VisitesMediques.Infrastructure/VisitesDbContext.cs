using Microsoft.EntityFrameworkCore;
using VisitesMediques.Domain;

namespace VisitesMediques.Infrastructure;

public class VisitesDbContext : DbContext
{
    public VisitesDbContext(DbContextOptions<VisitesDbContext> options) : base(options) { }

    public DbSet<VisitaMedica> VisitesMediques { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VisitaMedica>(entity =>
        {
            entity.ToTable("Visites Mediques");

            entity.HasKey(e => e.IdVisita);
            entity.Property(e => e.IdVisita)
                  .HasColumnName("Id_Visita") 
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.NomPacient)
                  .HasColumnName("Nom_Pacient")
                  .HasMaxLength(40)
                  .IsRequired(); 

            entity.Property(e => e.NomMetge)
                  .HasColumnName("Nom_Metge")
                  .HasMaxLength(40)
                  .IsRequired();

            entity.Property(e => e.Data)
                  .HasColumnName("Data")
                  .IsRequired();

            entity.Property(e => e.Diagnostic)
                  .HasColumnName("Diagnostic")
                  .HasMaxLength(250)
                  .IsRequired();
        });
    }
}