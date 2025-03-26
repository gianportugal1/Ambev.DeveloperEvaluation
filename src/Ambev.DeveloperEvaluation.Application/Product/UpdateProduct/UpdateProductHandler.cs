using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, UpdateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            return _mapper.Map<UpdateProductResult>(await _productRepository.PutAsync(_mapper.Map<Domain.Entities.Product>(command), cancellationToken));
        }
    }
}
