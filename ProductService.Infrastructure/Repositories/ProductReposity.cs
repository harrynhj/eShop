using Microsoft.EntityFrameworkCore;
using ProductService.ApplicationCore.Entities;
using ProductService.ApplicationCore.Repositories;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public ProductRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Product>> GetByCategoryId(int categoryId)
        {
            return await _DbContext.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<ICollection<Product>> GetByName(string name)
        {
            return await _DbContext.Products
                .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();
        }

        public async Task<ICollection<Product>> GetProducts(int page, int category)
        {
            
            return await _DbContext.Products
                .Where(p => category == -1 || p.CategoryId == category)
                .Skip((page - 1) * 10)
                .Take(10)
                .ToListAsync();
        }

        public async Task<bool> InactiveProduct(int id)
        {
            Product product = await _DbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                product.Qty = 0;
                var res = Update(product);
                if (res != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }
    }
}
