using System.ComponentModel.DataAnnotations;

namespace OptiqueAPI.ViewModels.Order
{
    public class CreateUpdateOrderViewModel
    {

        public Guid FournisseurId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
      
        public List<Guid> ProductIds { get; set; }
    }
}
