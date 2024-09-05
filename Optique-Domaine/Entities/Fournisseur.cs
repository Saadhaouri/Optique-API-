namespace Optique_Domaine.Entities;

public class Fournisseur
{
    public Guid Id { get; set; }
    public string Nom { get; set; }
    public string Adresse { get; set; }
    public string Telephone { get; set; }
    public ICollection<Product> Produits { get; set; }
    public ICollection<Achat> Achats { get; set; }
}
