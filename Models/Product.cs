using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace PointOfSale.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [IntegerValidator]
        public int ProductCategoryId { get; set; }
        
        [Required]
        [StringLength(100)]
        public required string Name { get; set; }

        public required ProductCategory ProductCategory { get; set; }
    }
}