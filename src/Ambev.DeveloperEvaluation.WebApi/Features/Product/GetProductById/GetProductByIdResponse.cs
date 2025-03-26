﻿namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProductById
{
    public class GetProductByIdResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string Cateory { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
