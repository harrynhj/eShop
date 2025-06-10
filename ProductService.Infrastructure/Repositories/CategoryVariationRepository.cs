using Microsoft.EntityFrameworkCore;
using ProductService.ApplicationCore.Entities;
using ProductService.ApplicationCore.Repositories;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories
{
    public class CategoryVariationRepository : BaseRepository<CategoryVariation>, ICategoryVariationRepository
    {

        public CategoryVariationRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<CategoryVariation>> GetByCategoryId(int categoryId)
        {
            return await _DbContext.CategoryVariations
                .Where(cv => cv.CategoryId == categoryId)
                .ToListAsync();
        }
    }
}
