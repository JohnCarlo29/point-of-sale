using System.ComponentModel.DataAnnotations;

namespace PointOfSale.DataTransferObjects
{
    public class LoginData
    {
        [Required]
        public required string Email { get; set; }
    
        [Required]
        public required string Password { get; set; }
    }
}