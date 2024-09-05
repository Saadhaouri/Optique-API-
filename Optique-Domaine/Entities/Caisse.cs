

namespace Optique_Domaine.Entities
{
    public class Caisse
    {
        public Guid Id { get; set; }
        public decimal Solde { get; set; }
        public ICollection<Vente> Ventes { get; set; }
        public ICollection<Achat> Achats { get; set; }
    }

}
