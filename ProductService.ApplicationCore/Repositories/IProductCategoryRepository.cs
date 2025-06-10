using ProductService.ApplicationCore.Entities;

namespace ProductService.ApplicationCore.Repositories
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        public Task<ICollection<ProductCategory>> GetByParentCategoryId(int parentId);

    }
}
