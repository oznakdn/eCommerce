using eCommerceAPI.Application.ViewModels.ProductViewModels;
using FluentValidation;

namespace eCommerceAPI.Application.ValidationRules.ProductValidators
{
    public class CreateProductValidator:AbstractValidator<CreateProductViewModel>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.ProductName).NotNull().NotEmpty().WithMessage("Product name is required!");
            RuleFor(product => product.ProductName).MinimumLength(2).MaximumLength(150).WithMessage("Product name must be between 2 or 150  characters!");
            RuleFor(product => product.Stock).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(1000).WithMessage("Stock quantity must be between 0 or 1000!");
            RuleFor(product=>product.Price).NotNull().GreaterThan(0).WithMessage("Price must be greater than 0!");
        }
    }
}
