using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductValidator()
        {
            RuleFor(product => product.Title).NotEmpty().Length(3, 50);
            RuleFor(product => product.Description).NotEmpty().Length(0, 200);
            RuleFor(product => product.Cateory).NotEmpty().Length(3, 50);
        }
    }
}
