using FluentValidation;

namespace Mvc_Example.Models.Validators
{
    public class ProductSecondValidator :AbstractValidator<Product>
    {
        public ProductSecondValidator()
        {
            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Quantity Null ifade olamaz");
        }
    }
}
