using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProductById
{
    public class GetProductByIdCommand : IRequest<GetProductByIdResult>
    {
        public Guid Id { get; }

        public GetProductByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
