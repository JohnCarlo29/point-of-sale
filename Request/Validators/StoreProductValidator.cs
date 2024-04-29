using FluentValidation;

namespace PointOfSale.Request
{
    public class StoreProductValidator: AbstractValidator<StoreProductRequest>
    {
        public StoreProductValidator()
        {
            RuleFor(x => x.Name).NotNull()
                .NotEmpty();
            RuleFor(x => x.Price).NotNull()
                .GreaterThan(0)
                .PrecisionScale(10, 2, false);
            RuleFor(x => x.Stock).GreaterThan(0);
            RuleFor(x => x.ProductCategoryId).NotNull()
                .GreaterThan(0);
        }
    }
}