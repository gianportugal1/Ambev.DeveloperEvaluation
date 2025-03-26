using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Product.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Product.GetCategories;
using Ambev.DeveloperEvaluation.Application.Product.GetProductById;
using Ambev.DeveloperEvaluation.Application.Product.GetProducts;
using Ambev.DeveloperEvaluation.Application.Product.GetProductsByCategory;
using Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProductById;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProductsByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.UpdateProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRequest, CreateProductCommand>();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductResult>();
            CreateMap<CreateProductResult, CreateProductResponse>();
            CreateMap<Product, GetProductsResult>();
            CreateMap<GetProductsResult, GetProductsResponse>();
            CreateMap<GetProductByIdRequest, GetProductByIdCommand>();
            CreateMap<Product, GetProductByIdResult>();
            CreateMap<GetProductByIdResult, GetProductByIdResponse>();
            CreateMap<DeleteProductRequest, DeleteProductCommand>();
            CreateMap<UpdateProductRequest, UpdateProductCommand>();
            CreateMap<UpdateProductCommand, Product>();
            CreateMap<Product, UpdateProductResult>();
            CreateMap<UpdateProductResult, UpdateProductResponse>();
            CreateMap<string, GetCategoriesResult>();
            CreateMap<GetCategoriesResult, GetCategoriesResponse>();
            CreateMap<GetProductsByCategoryRequest, GetProductsByCategoryCommand>();
            CreateMap<Product, GetProductsByCategoryResult>();
            CreateMap<GetProductsByCategoryResult, GetProductsByCategoryResponse>();            
        }
    }
}

