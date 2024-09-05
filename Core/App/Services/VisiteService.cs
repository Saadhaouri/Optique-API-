using AutoMapper;
using Core.App.Dto;
using Core.App.Interfaces;
using Core.App.IServices;
using Optique_Domaine.Entities;

namespace Core.App.Services
{
    public class VisiteService : IVisiteService
    {
        private readonly IVisiteRepository _visiteRepository;
        private readonly IMapper _mapper;

        public VisiteService(IVisiteRepository visiteRepository, IMapper mapper)
        {
            _visiteRepository = visiteRepository;
            _mapper = mapper;
        }

        public void CreateVisite(CreateUpdateVisiteDto createUpdateVisiteDto)
        {
            var visite = _mapper.Map<Visite>(createUpdateVisiteDto);
            _visiteRepository.AddVisite(visite);
        }

        public VisiteDto GetVisiteById(Guid visiteId)
        {
            var visite = _visiteRepository.GetVisiteById(visiteId);
            return _mapper.Map<VisiteDto>(visite);
        }

        public IEnumerable<VisiteDto> GetAllVisites()
        {
            var visites = _visiteRepository.GetAllVisites();
            return _mapper.Map<IEnumerable<VisiteDto>>(visites);
        }

        public void UpdateVisite(Guid visiteId, CreateUpdateVisiteDto updateVisiteDto)
        {
            var visite = _visiteRepository.GetVisiteById(visiteId);
            if (visite != null)
            {
                visite.Fullname = updateVisiteDto.Fullname;  // Update full name of the client
                visite.Telephone = updateVisiteDto.Telephone; // Update phone number of the client
                visite.DateVisite = updateVisiteDto.DateVisite;

                visite.OS_Axis = updateVisiteDto.OS_Axis;
                visite.OS_Cylinder = updateVisiteDto.OS_Cylinder;
                visite.OS_Sphere = updateVisiteDto.OS_Sphere;

                visite.OD_Axis = updateVisiteDto.OD_Axis;
                visite.OD_Cylinder = updateVisiteDto.OD_Cylinder;
                visite.OD_Sphere = updateVisiteDto.OD_Sphere;

                visite.Add = updateVisiteDto.Add;
                visite.PD = updateVisiteDto.PD;

                visite.VerreOD = updateVisiteDto.VerreOD;  // Update Verre for the right eye
                visite.VerreOS = updateVisiteDto.VerreOS;  // Update Verre for the left eye

                visite.PriceOD = updateVisiteDto.PriceOD;  // Update Price for the right eye
                visite.PriceOS = updateVisiteDto.PriceOS;  // Update Price for the left eye

                visite.Prixmonture = updateVisiteDto.Prixmonture;

                visite.Total = updateVisiteDto.Total;
                visite.Remise = updateVisiteDto.Remise;
                visite.Avance = updateVisiteDto.Avance;
                visite.Reste = updateVisiteDto.Reste;

                visite.Doctor = updateVisiteDto.Doctor;

                _visiteRepository.Save();
            }
        }


        public void DeleteVisite(Guid visiteId)
        {
            var visite = _visiteRepository.GetVisiteById(visiteId);
            if (visite != null)
            {
                _visiteRepository.DeleteVisite(visiteId);
            }
        }
        public IEnumerable<Guid> GetClientIdsWithNonZeroReset()
        {
            var visites = _visiteRepository.GetAllVisites()
                             .Where(v => v.Reste != 0)
                             .Select(v => v.Id)
                             .Distinct();

            return visites;
        }


        public IEnumerable<VisiteDto> GetVisitesOfCurrentDay()
        {
            var today = DateTime.Today;
            var visites = _visiteRepository.GetAllVisites()
                            .Where(v => v.DateVisite.Date == today);
            return _mapper.Map<IEnumerable<VisiteDto>>(visites);
        }

        public IEnumerable<VisiteDto> GetVisitesOfCurrentWeek()
        {
            var today = DateTime.Today;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7).AddTicks(-1);
            var visites = _visiteRepository.GetAllVisites()
                            .Where(v => v.DateVisite >= startOfWeek && v.DateVisite <= endOfWeek);
            return _mapper.Map<IEnumerable<VisiteDto>>(visites);
        }

        public IEnumerable<VisiteDto> GetVisitesOfCurrentMonth()
        {
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);
            var visites = _visiteRepository.GetAllVisites()
                            .Where(v => v.DateVisite >= startOfMonth && v.DateVisite <= endOfMonth);
            return _mapper.Map<IEnumerable<VisiteDto>>(visites);
        }

        public IEnumerable<VisiteDto> GetVisitesNeedingBeforeMonthEnd()
        {
            var today = DateTime.Today;
            var endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            var visitesDue = _visiteRepository.GetAllVisites()
                                  .Where(v => v.DateVisite.AddMonths(1) <= endOfMonth)
                                  .Distinct();

            return _mapper.Map<IEnumerable<VisiteDto>>(visitesDue);
        }


        public decimal GetTotalOfCurrentWeek()
        {
            var today = DateTime.Today;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            var endOfWeek = startOfWeek.AddDays(7).AddTicks(-1);
            var total = _visiteRepository.GetAllVisites()
                            .Where(v => v.DateVisite >= startOfWeek && v.DateVisite <= endOfWeek)
                            .Sum(v => v.Total);
            return total;
        }

        public decimal GetTotalOfCurrentMonth()
        {
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1).AddTicks(-1);
            var total = _visiteRepository.GetAllVisites()
                            .Where(v => v.DateVisite >= startOfMonth && v.DateVisite <= endOfMonth)
                            .Sum(v => v.Total);
            return total;
        }


    }
}
