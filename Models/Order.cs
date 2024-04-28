namespace PointOfSale.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public float TotalPrice { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}