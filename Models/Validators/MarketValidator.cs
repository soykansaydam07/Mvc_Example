using FluentValidation;

namespace Mvc_Example.Models.Validators
{
    public class MarketValidator :AbstractValidator<Market>
    {
        public MarketValidator()
        {
            RuleFor(x => x.MarketName)
                .NotEmpty().WithMessage("Market İsmi boş olamaz");
            RuleFor(x => x.MarketEmail)
                .NotNull().WithMessage("Email Boş olamaz")
                .EmailAddress().WithMessage("Lütfen Doğru bir email giriniz");
        }

    }
}
