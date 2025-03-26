using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProductsByCategory
{
    public class GetProductsByCategoryCommand : IRequest<List<GetProductsByCategoryResult>>
    {
        public string? Category { get; set; }

        public GetProductsByCategoryCommand(string? category)
        {
            Category = category;
        }
    }
}
