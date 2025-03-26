namespace Ambev.DeveloperEvaluation.Application.Product.GetProductsByCategory
{
    public class GetProductsByCategoryResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public string Cateory { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
