using ProductService.ApplicationCore.Entities;
using ProductService.ApplicationCore.Repositories;
using ProductService.Infrastructure.Data;

namespace ProductService.Infrastructure.Repositories
{
    public class VariationValueRepository : BaseRepository<VariationValue>, IVariationValueRepository
    {

        public VariationValueRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }
    }



}
