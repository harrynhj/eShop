using ProductService.ApplicationCore.Entities;


namespace ProductService.ApplicationCore.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        public Task<ICollection<Product>> GetByCategoryId(int categoryId);
        public Task<ICollection<Product>> GetByName(string name);
        public Task<bool> InactiveProduct(int id);
        public Task<ICollection<Product>> GetProducts(int page, int category);

    }
}
