namespace PointOfSale.Request
{
    public class StoreProductRequest
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int ProductCategoryId { get; set; }
    }
}