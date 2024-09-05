namespace Optique_Domaine.Entities;

public class AchatProduct
{
    public Guid AchatId { get; set; }
    public Achat Achat { get; set; }
    public Guid ProductId { get; set; }
    public Product Produit { get; set; }


}
