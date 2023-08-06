using FluentValidation;

namespace Mvc_Example.Models.Validators
{
    public class ProductInfoValidator : AbstractValidator<ProductInfo>
    {
        //RuleForEach her bir indis için bunu yapıcaktır ayrıca Collection Index hangi index sıkıntılı söylemektedir 
        public ProductInfoValidator()
        {
            //RuleForEach(x => x.ProductDescriptions).NotNull().WithMessage("Address {CollectionIndex} is required.");
            RuleFor(x => x.ProductDescription).NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
