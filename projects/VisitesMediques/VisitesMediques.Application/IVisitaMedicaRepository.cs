using VisitesMediques.Domain;

namespace VisitesMediques.Application;

public interface IVisitaMedicaRepository
{
    Task<IEnumerable<VisitaMedica>> GetAllAsync();
    Task<VisitaMedica?> GetByIdAsync(int id);
    Task<VisitaMedica> AddAsync(VisitaMedica visita);
    Task UpdateAsync(VisitaMedica visita);
    Task DeleteAsync(int id);
}