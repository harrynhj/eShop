using ProductService.ApplicationCore.Entities;
using ProductService.ApplicationCore.Repositories;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductVariationValueRepository : BaseRepository<ProductVariationValues>, IProductVariationValueRepository
    {

        public ProductVariationValueRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }
    }
}
