namespace Core.App.Dto.AchatDTO;

public class AchatCreateUpdateDTO
{
    public DateTime DateAchat { get; set; }
    public Guid FournisseurId { get; set; }
    public decimal Total { get; set; }
    public List<Guid> ProduitIds { get; set; } 
}
