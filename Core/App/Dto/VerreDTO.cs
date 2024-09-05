using Optique_Domaine.Entities;

namespace Core.App.Dto
{
    public class VerreDTO
    {
        public Guid Id { get; set; }  // Identifiant unique du verre
        public string Type { get; set; }  // Type de verre (par exemple, unifocal, progressif)
        public string Marque { get; set; }  // Marque du verre
        public string Materiel { get; set; }  // Matériau du verre (par exemple, polycarbonate, verre)
        public decimal Prix { get; set; }  // Prix du verre
        public Guid VisiteId { get; set; }
        
    }
}
