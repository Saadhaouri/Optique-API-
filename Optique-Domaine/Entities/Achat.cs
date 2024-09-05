namespace Optique_Domaine.Entities;

public class Achat
{
    public Guid Id { get; set; }
    public DateTime DateAchat { get; set; }
    public decimal Total { get; set; }
    public Guid FournisseurId { get; set; }
    public Fournisseur ?Fournisseur { get; set; }
    public List<AchatProduct> ?AchatProducts { get; set; }
}
