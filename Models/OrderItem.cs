using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace PointOfSale.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [ForeignKey("ProductId")]
        [Required]
        [IntegerValidator]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [Required]
        [IntegerValidator]
        public int OrderId { get; set; }

        [Required]
        [IntegerValidator]
        public int Quantity { get; set; }

        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public float AvailedPrice { get; set; }

        [Required]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public float TotalPrice { get; set; }
    }
}
