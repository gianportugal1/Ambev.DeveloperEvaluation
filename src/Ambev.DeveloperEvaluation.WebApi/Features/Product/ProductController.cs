using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Product.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Product.GetCategories;
using Ambev.DeveloperEvaluation.Application.Product.GetProductById;
using Ambev.DeveloperEvaluation.Application.Product.GetProductsByCategory;
using Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProductById;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProductsByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product
{
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductRequestValidator(); 
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
            {
                Success = true,
                Message = "Product created successfully",
                Data = _mapper.Map<CreateProductResponse>(response)
            });
        }

        [HttpPut]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<UpdateProductResponse>
            {
                Success = true,
                Message = "Product updated successfully",
                Data = _mapper.Map<UpdateProductResponse>(response)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<List<GetProductsResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetProductsCommand(), cancellationToken);

            return Ok(new ApiResponseWithData<List<GetProductsResponse>>
            {
                Success = true,
                Message = "Products retrieved successfully",
                Data = _mapper.Map<List<GetProductsResponse>>(response)
            });
        }

        [HttpGet("categories")]
        [ProducesResponseType(typeof(ApiResponseWithData<List<string>?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetCategoriesCommand(), cancellationToken);

            return Ok(new ApiResponseWithData<List<string>?>
            {
                Success = true,
                Message = "Categories retrieved successfully",
                Data = response
            });
        }

        [HttpGet("category/{name}")]
        [ProducesResponseType(typeof(ApiResponseWithData<List<GetProductsResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductsByCategory([FromRoute] string name, CancellationToken cancellationToken)
        {
            var request = new GetProductsByCategoryRequest { Category = name };

            if (request.Category == null)
                return BadRequest("Category name is required");

            var command = _mapper.Map<GetProductsByCategoryCommand>(request.Category);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<List<GetProductsByCategoryResponse>>
            {
                Success = true,
                Message = "Products by category retrieved successfully",
                Data = _mapper.Map<List<GetProductsByCategoryResponse>>(response)
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetProductByIdResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetProductByIdRequest { Id = id };
            var validator = new GetProductByIdRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetProductByIdCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetProductByIdResponse>
            {
                Success = true,
                Message = "Product retrieved successfully",
                Data = _mapper.Map<GetProductByIdResponse>(response)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteProductRequest { Id = id };
            var validator = new DeleteProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteProductCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Product deleted successfully"
            });
        }
    }
}
