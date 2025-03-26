using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProducts;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProducts
{
    public class GetProductsHandler : IRequestHandler<GetProductsCommand, List<GetProductsResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductsResult>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAsync(cancellationToken);
            return products == null ? throw new KeyNotFoundException($"Products not found") : _mapper.Map<List<GetProductsResult>>(products);
        }
    }
}
