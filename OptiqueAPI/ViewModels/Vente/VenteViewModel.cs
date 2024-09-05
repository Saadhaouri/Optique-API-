namespace OptiqueAPI.ViewModels.Vente
{
    public class VenteViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Profit { get; set; }

        public DateTime VenteDate { get; set; }
    }

}
