using GestioVisites.Domain.Entities;

namespace GestioVisites.Domain.Interfaces
{
    public interface IVisitaMedicaRepository
    {
        void Create(VisitaMedica visita);
        IEnumerable<VisitaMedica> GetAll();
        VisitaMedica? GetById(int id);
        void Update(VisitaMedica visita);
        void Delete(int id);
    }
}