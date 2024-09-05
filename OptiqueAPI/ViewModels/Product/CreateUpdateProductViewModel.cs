namespace OptiqueAPI.ViewModels.Product;

public class CreateUpdateProductViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal PriceForSale { get; set; } // New property for sale price
    public int Quantity { get; set; }
    public int stock { get; set; }
    public Guid FournisseurId { get; set; }
    public Guid CategoryID { get; set; }
}
