using FluentValidation;

namespace Ordering.Application.Feature.Order.Command.CheckoutOrder
{
    //PreProcessing before checkout via fluent validation
    public class CheckoutOrderCommandValidator : AbstractValidator<CheckoutOrderCommand>
    {
        public CheckoutOrderCommandValidator()
        {
            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("{UserName} is required")
                .NotNull()
                .MaximumLength(70)
                .WithMessage("{UserName} must not exceed 70 characters");

            RuleFor(p => p.EmailAddress)
                .NotEmpty()
                .WithMessage("{EmailAddress} is required.");

            //Maybe you get lucky and get the product for free, who knows
            RuleFor(p => p.TotalPrice)
                .NotEmpty()
                .WithMessage("{TotalPrice} is required.")
                .GreaterThan(-1)
                .WithMessage("{TotalPrice} should not be -ve.");
        }
    }
}
