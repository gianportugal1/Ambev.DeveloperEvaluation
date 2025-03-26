using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetCategories
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesCommand, List<string>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetCategoriesHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<string>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
        {
            var categories = await _productRepository.GetCategoriesAsync(cancellationToken);
            return categories ?? [];
        }
    }
}
