namespace Optique_Domaine.Entities;

public class Facture
{
    public Guid Id { get; set; }
    public string NFacture { get; set; }
   
    public DateTime DateFacture { get; set; }
    public Guid  VisiteId  { get; set; }
    public Visite Visite { get; set; }

}
