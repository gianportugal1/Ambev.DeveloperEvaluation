using Ambev.DeveloperEvaluation.Application.Product.GetProducts;
using MediatR;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProducts
{
    public class GetProductsCommand : IRequest<List<GetProductsResult>>
    {
    }
}