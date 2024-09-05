using Core.App.Dto;

namespace Core.App.IServices;

public interface IFournisseurService
{
    IEnumerable<FournisseurDTO> GetFournisseurs();
    FournisseurDTO GetFournisseurById(Guid fournisseurId);
    void InsertFournisseur(FournisseurDTO fournisseurDto);
    void UpdateFournisseur(Guid Id , FournisseurDTO fournisseurDto);
    void DeleteFournisseur(Guid fournisseurId);
}
