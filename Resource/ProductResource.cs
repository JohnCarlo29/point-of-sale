namespace PointOfSale.Resource
{
    public class ProductResource
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public int ProductCategoryId { get; set; }
        public required ProductCategoryResource ProductCategory { get; set; }
    }
}