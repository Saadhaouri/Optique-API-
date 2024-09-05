using Core.App.Dto;

namespace Core.App.IServices
{
    public interface IVisiteService
    {
        void CreateVisite(CreateUpdateVisiteDto createUpdateVisiteDto);
        VisiteDto GetVisiteById(Guid visiteId);
        IEnumerable<VisiteDto> GetAllVisites();
        void UpdateVisite(Guid visiteId, CreateUpdateVisiteDto updateVisiteDto);
        void DeleteVisite(Guid visiteId);

        // New methods
        IEnumerable<VisiteDto> GetVisitesOfCurrentDay();
        IEnumerable<VisiteDto> GetVisitesOfCurrentWeek();
        IEnumerable<VisiteDto> GetVisitesOfCurrentMonth();
        IEnumerable<VisiteDto> GetVisitesNeedingBeforeMonthEnd();
        decimal GetTotalOfCurrentWeek();
        decimal GetTotalOfCurrentMonth();
        // New method to get client IDs where Visite.reset != 0
        IEnumerable<Guid> GetClientIdsWithNonZeroReset();


    }
}
