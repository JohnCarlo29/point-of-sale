namespace PointOfSale.DataTransferObjects
{
    public class OrderItemData
    {
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int ProductId { get; set; }
    }
}