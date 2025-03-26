using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;

        public ProductRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task<List<Product>?> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        public async Task<Product> PostAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<Product> PutAsync(Product product, CancellationToken cancellationToken = default)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var product = _context.Products.FirstOrDefault(o => o.Id == id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<string>?> GetCategoriesAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _context.Products.Select(p => p.Cateory).Distinct().ToListAsync(cancellationToken);
            return categories;
        }

        public async Task<List<Product>?> GetProductsByCategoryAsync(string category, CancellationToken cancellationToken = default)
        {
            var products = await _context.Products.Where(p => p.Cateory.Equals(category, StringComparison.CurrentCultureIgnoreCase)).ToListAsync(cancellationToken);
            return products;
        }
    }
}
