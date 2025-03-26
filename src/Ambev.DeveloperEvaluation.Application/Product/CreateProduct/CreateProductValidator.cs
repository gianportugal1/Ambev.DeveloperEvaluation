using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(product => product.Title).NotEmpty().Length(3, 50);
            RuleFor(product => product.Description).NotEmpty().Length(0, 200);
            RuleFor(product => product.Cateory).NotEmpty().Length(3, 50);
        }
    }
}
