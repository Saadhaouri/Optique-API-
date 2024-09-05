using Optique_Domaine.Entities;

namespace Core.App.Interfaces;

public interface IFactureRepository
{
    IEnumerable<Facture> GetFactures();
    Facture GetFactureById(Guid factureId);
    void InsertFacture(Facture facture);
    void UpdateFacture(Facture facture);
    void DeleteFacture(Guid factureId);
    void Save();
}
