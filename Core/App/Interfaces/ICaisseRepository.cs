using Optique_Domaine.Entities;

namespace Core.App.Interfaces;

public interface ICaisseRepository
{
    IEnumerable<Caisse> GetCaisses();
    Caisse GetCaisseById(Guid caisseId);
    void InsertCaisse(Caisse caisse);
    void UpdateCaisse(Caisse caisse);
    void DeleteCaisse(Guid caisseId);
    void Save();
}
