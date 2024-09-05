namespace Optique_Domaine.Entities;

public class Verre
{
    public Guid Id { get; set; }  // Identifiant unique du verre
    public string Type { get; set; }  // Type de verre (par exemple, unifocal, progressif)
    public string Marque { get; set; }  // Marque du verre
    public string Materiel { get; set; }  // Matériau du verre (par exemple, polycarbonate, verre)
    public decimal Prix { get; set; }  // Prix du verre

}
