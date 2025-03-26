using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>?> GetAsync(CancellationToken cancellationToken = default);
        Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Product> PostAsync(Product product, CancellationToken cancellationToken = default);
        Task<Product> PutAsync(Product product, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<List<string>?> GetCategoriesAsync(CancellationToken cancellationToken = default);
        Task<List<Product>?> GetProductsByCategoryAsync(string category, CancellationToken cancellationToken = default);
    }
}
