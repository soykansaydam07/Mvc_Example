using FluentValidation;

namespace Mvc_Example.Models.Validators
{
    public class ProductValidator :AbstractValidator<Product>
    {
        public ProductValidator()
        {
            
            RuleFor(x => x.ProductName)
                .NotNull().WithMessage("Product Name Null olamaz.")
                .NotEmpty().WithMessage("Product Name Boş olamaz.") //Veya ile bağlayarak devam eder
                .MaximumLength(100).WithMessage("Maksimum karakter 100 ü geçemez")
                .Length(2, 101).WithMessage("Name 2 ile 100 arasında karaktere sahip olmalıdır ");
            
            RuleFor(x => x.Quantity)
                .GreaterThan(2).WithMessage("Stok ikiden küçük olamaz");
            
            RuleFor(x => x.UserEmail)
                .EmailAddress().WithMessage("Geçerli bir Eposta adresi giriniz")
                .When(x => !string.IsNullOrEmpty(x.UserEmail));//When parametresi şarta bağlamak için kullanılır 
            
            RuleFor(x => x.MarketData)
                .SetValidator(new MarketValidator());
            
            RuleForEach(x => x.ProductInfos)
                .SetValidator(new ProductInfoValidator());
            
            RuleFor(x => x.Id)
                .GreaterThan(100)
                .When(x => x.IsFoodProduct).WithMessage("Ürün yiyecek ise Id 100 den büyük olmalıdır ");
            
            RuleFor(x => x.ProductName)
                .Must(y => y == "Elma").WithMessage("Ürün ismi elma harici olamaz");
            
            When(x => x.IsFoodProduct, () =>
            {
                RuleFor(x => x.Id)
                .GreaterThan(100).WithMessage("Id yüz den büyük olmalıdır");
                RuleFor(x => x.Id)
                .LessThan(10000).WithMessage("Id on bin den küçük olmalıdır");
            }).Otherwise(() =>
            {
                RuleFor(x => x.Id)
                .Equal(1).WithMessage("Id yüz ile on bin den farklı bir durum olamaz");
            });

            RuleFor(x => x.ProductNumber)
                .Matches("^[0-9][0-9^\\-]*$").WithMessage("Sadece Numeric Takım kullanılabilir");

            Include(new ProductSecondValidator());

            RuleSet("ProductPrivateRule", () =>
            {
                RuleFor(x => x.ProductName)
               .NotNull().WithMessage("Product Name Null olamaz.");
            });


            //Custom Validation//

            //Verify

            RuleFor(x => x.ProductInfos)
                .Must(list => list.Count < 10).WithMessage("Liste en fazla on eleman bulunabilir ");

            RuleFor(x => x.ProductInfos).ListMustUpperThan(10);

            //Write

            RuleFor(x => x.ProductInfos).Custom((list, context) => {
                if (list.Count > 10)
                {
                    context.AddFailure("Liste en fazla on eleman bulunabilir(Second)");
                }
            });

            RuleFor(x => x.ProductInfos).ListMustUpperSecond(5);
        }
    }
}
