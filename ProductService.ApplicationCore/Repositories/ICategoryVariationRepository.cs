using ProductService.ApplicationCore.Entities;


namespace ProductService.ApplicationCore.Repositories
{
    public interface ICategoryVariationRepository : IBaseRepository<CategoryVariation>
    {
        public Task<ICollection<CategoryVariation>> GetByCategoryId(int categoryId);
    }
}
