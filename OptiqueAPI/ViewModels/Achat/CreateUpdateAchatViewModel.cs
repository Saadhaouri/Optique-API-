namespace OptiqueAPI.ViewModels.Achat;

public class CreateUpdateAchatViewModel
{
    public DateTime DateAchat { get; set; }
    public Guid FournisseurId { get; set; }
    public decimal Total { get; set; }
    public List<Guid> ProduitIds { get; set; } // List of Product IDs
}
