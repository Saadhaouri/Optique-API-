namespace Optique_Domaine.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal PriceForSale { get; set; } // New property for sale price
    public int Quantity { get; set; }
    public int  stock { get; set; }
    public Guid FournisseurId { get; set; }
    public Guid CategoryID { get; set; }
    public Category Category { get; set; }
    public Fournisseur Fournisseur { get; set; }
    public ICollection<AchatProduct> AchatProduits { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
