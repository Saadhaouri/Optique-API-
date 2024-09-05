namespace OptiqueAPI.ViewModels.Facture;

public class CreateFactureViewModel
{
    public string NFacture { get; set; }
 
    public DateTime DateFacture { get; set; }
    public Guid VisiteId { get; set; }
}
