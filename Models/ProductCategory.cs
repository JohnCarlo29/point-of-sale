using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PointOfSale.Models
{
    [Table("ProductCategories")]
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public List<Product> Products { get; } = [];
    }
}