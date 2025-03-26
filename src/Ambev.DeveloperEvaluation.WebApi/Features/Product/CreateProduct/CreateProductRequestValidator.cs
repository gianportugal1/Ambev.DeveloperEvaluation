using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(product => product.Title).NotEmpty().Length(3, 50);
            RuleFor(product => product.Description).NotEmpty().Length(0, 200);
            RuleFor(product => product.Cateory).NotEmpty().Length(3, 50);
        }
    }
}
