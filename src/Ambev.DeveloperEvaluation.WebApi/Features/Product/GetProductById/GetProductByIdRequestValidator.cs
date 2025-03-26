using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProductById
{
    public class GetProductByIdRequestValidator : AbstractValidator<GetProductByIdRequest>
    {
        public GetProductByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
        }
    }
}
