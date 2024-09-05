using Optique_Domaine.Entities;

namespace Core.App.Dto.VenteDTO;

public class CreateUpdateVenteDto
{
   
    public DateTime DateVente { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity  { get; set; }
    public decimal Price { get; set; }
    public decimal Profit { get; set; }



}
