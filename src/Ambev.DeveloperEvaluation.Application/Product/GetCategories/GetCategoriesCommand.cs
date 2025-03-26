using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetCategories
{
    public class GetCategoriesCommand : IRequest<List<string>>
    {
    }
}
