using Microsoft.EntityFrameworkCore;
using ProductService.ApplicationCore.Entities;
using ProductService.ApplicationCore.Repositories;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {

        public ProductCategoryRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<ProductCategory>> GetByParentCategoryId(int parentId)
        {
            return await _DbContext.ProductCategories
                .Where(c => c.ParentCategoryId == parentId)
                .ToListAsync();
        }
    }
}
