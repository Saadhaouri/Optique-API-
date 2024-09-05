
namespace Core.App.Dto;

public class FactureDTO
{
    public Guid Id { get; set; }
    public string NFacture { get; set; }
    public DateTime DateFacture { get; set; }
    public Guid VisiteId { get; set; }
    public VisiteDto Visite { get; set; }

}
