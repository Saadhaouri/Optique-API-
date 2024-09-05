using Core.App.Dto;
using Core.App.Dto.VenteDTO;

namespace Core.App.IServices;

public interface IVenteService
{
    void CreateVente(CreateUpdateVenteDto createVenteDto);
    VenteDto GetVenteById(Guid venteId);
    IEnumerable<VenteDto> GetVentes();
    void UpdateVente(Guid venteId, CreateUpdateVenteDto updateVenteDto);
    void DeleteVente(Guid venteId);
    IEnumerable<VenteDto> GetDailySales();
    IEnumerable<VenteDto> GetWeeklySales();
    IEnumerable<VenteDto> GetMonthlySales();
    decimal GetTotalDailyProfit();
    decimal GetTotalWeeklyProfit();
    decimal GetTotalMonthlyProfit();
    
    void DeleteAllSales();
    IEnumerable<MonthlyBenefitDto> GetMonthlyBenefits();  // Method to get monthly benefits
}
