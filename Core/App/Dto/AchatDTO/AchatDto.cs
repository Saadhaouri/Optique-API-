

namespace Core.App.Dto.AchatDTO;

public class AchatDto
{
    public Guid Id { get; set; }
    public DateTime DateAchat { get; set; }
    public decimal Total { get; set; }
    public Guid FournisseurId { get; set; }
    public List<Guid> ProductIds { get; set; }

}
