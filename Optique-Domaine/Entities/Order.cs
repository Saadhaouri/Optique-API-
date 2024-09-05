using Optique_Domaine.Entities;

namespace Optique_Domaine.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid FournisseurId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public Fournisseur Fournisseur { get; set; }
    public List<OrderProduct> OrderProducts { get; set; }
}
