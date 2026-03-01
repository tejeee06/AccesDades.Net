using GestioVisites.Application.DTOs;
using GestioVisites.Domain.Entities;
using GestioVisites.Domain.Interfaces;

namespace GestioVisites.Application.Services
{
    public class VisitaMedicaService
    {
        private readonly IVisitaMedicaRepository _repository;

        public VisitaMedicaService(IVisitaMedicaRepository repository)
        {
            _repository = repository;
        }

        public void RegistrarVisita(VisitaMedicaDTO dto)
        {
            var visita = new VisitaMedica
            {
                NomPacient = dto.NomPacient,
                NomMetge = dto.NomMetge,
                DataVisita = dto.DataVisita,
                Diagnostic = dto.Diagnostic
            };

            _repository.Create(visita);
        }

        public IEnumerable<VisitaMedicaDTO> ObtenirVisites()
        {
            var visitas = _repository.GetAll();

            return visitas.Select(v => new VisitaMedicaDTO
            {
                Id = v.PK_VisitaMedicaID,
                NomPacient = v.NomPacient,
                NomMetge = v.NomMetge,
                DataVisita = v.DataVisita,
                Diagnostic = v.Diagnostic
            });
        }
        
        public VisitaMedicaDTO? ObtenirVisitaPerId(int id)
        {
            var v = _repository.GetById(id);
            if (v == null) return null;

            return new VisitaMedicaDTO
            {
                Id = v.PK_VisitaMedicaID,
                NomPacient = v.NomPacient,
                NomMetge = v.NomMetge,
                DataVisita = v.DataVisita,
                Diagnostic = v.Diagnostic
            };
        }

        public void ActualitzarVisita(VisitaMedicaDTO dto)
        {
            var visita = new VisitaMedica
            {
                PK_VisitaMedicaID = dto.Id,
                NomPacient = dto.NomPacient,
                NomMetge = dto.NomMetge,
                DataVisita = dto.DataVisita,
                Diagnostic = dto.Diagnostic
            };
            _repository.Update(visita);
        }

        public void EliminarVisita(int id)
        {
            _repository.Delete(id);
        }
    }
}