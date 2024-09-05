using Core.App.Dto;

namespace Core.App.IServices;

public interface IFactureService
{
    IEnumerable<FactureDTO> GetFactures();
    FactureDTO GetFactureById(Guid factureId);
    void InsertFacture(FactureDTO factureDto);
    void UpdateFacture(FactureDTO factureDto);
    void DeleteFacture(Guid factureId);
}
