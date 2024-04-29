using FluentValidation;

namespace PointOfSale.Request
{
    public class StoreProductCategory
    {
        public required string Name { get; set; }
    }
}