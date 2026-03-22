using Microsoft.EntityFrameworkCore;
using VisitesMediques.Application;
using VisitesMediques.Domain;

namespace VisitesMediques.Infrastructure;

public class VisitaMedicaRepository : IVisitaMedicaRepository
{
    private readonly VisitesDbContext _context;

    public VisitaMedicaRepository(VisitesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<VisitaMedica>> GetAllAsync() => await _context.VisitesMediques.ToListAsync();
    
    public async Task<VisitaMedica?> GetByIdAsync(int id) => await _context.VisitesMediques.FindAsync(id);

    public async Task<VisitaMedica> AddAsync(VisitaMedica visita)
    {
        _context.VisitesMediques.Add(visita);
        await _context.SaveChangesAsync();
        return visita;
    }

    public async Task UpdateAsync(VisitaMedica visita)
    {
        _context.Entry(visita).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var visita = await _context.VisitesMediques.FindAsync(id);
        if (visita != null)
        {
            _context.VisitesMediques.Remove(visita);
            await _context.SaveChangesAsync();
        }
    }
}