using FluentValidation;

namespace PointOfSale.Request
{
    public class StoreProductCategoryValidator: AbstractValidator<StoreProductCategory>
    {
        public StoreProductCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull()
                .NotEmpty();
        }
    }
}