using Optique_Domaine.Entities;

namespace Core.App.Interfaces;

public interface IProduitRepository
{
    IEnumerable<Product> GetProduits();
    Product GetProduitById(Guid produitId);
    void InsertProduit(Product produit);
    void UpdateProduit(Product produit);
    void DeleteProduit(Guid produitId);
    void Save();
}

