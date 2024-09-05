

namespace Core.App.Dto.OrderDTO;

public class OrderDto
{
    public Guid Id { get; set; }
    public Guid FournisseurId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Status { get; set; }
    public Guid ClientId { get; set; }
    public List<Guid> ProductIds { get; set; }

}
