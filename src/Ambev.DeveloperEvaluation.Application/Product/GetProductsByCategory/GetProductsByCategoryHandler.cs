using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProductsByCategory
{
    public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryCommand, List<GetProductsByCategoryResult>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsByCategoryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductsByCategoryResult>> Handle(GetProductsByCategoryCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(request?.Category ?? "", cancellationToken);

            return products == null
                ? throw new KeyNotFoundException($"Products with category {request?.Category ?? ""} were not found")
                : _mapper.Map<List<GetProductsByCategoryResult>>(products);
        }
    }
}
