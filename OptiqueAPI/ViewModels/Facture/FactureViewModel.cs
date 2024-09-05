using OptiqueAPI.ViewModels.Visite;

namespace OptiqueAPI.ViewModels.Facture;

public class FactureViewModel
{
    public Guid Id { get; set; }
    public string NFacture { get; set; }
    
    public DateTime DateFacture { get; set; }
    public Guid VisiteId { get; set; }
   
}
