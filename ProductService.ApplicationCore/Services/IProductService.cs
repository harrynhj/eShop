using ProductService.ApplicationCore.Entities;
using ProductService.ApplicationCore.Models;
using ProductService.ApplicationCore.Repositories;

namespace ProductService.ApplicationCore.Services
{
    public interface IProductService
    {
        public Task<int> SaveCategory(CategoryRequestModel model);
        public Task<ICollection<CategoryViewModel>> GetAllCategory();
        public Task<CategoryViewModel> GetCategoryById(int id);
        public Task<bool> DeleteCategory(int id);
        public Task<ICollection<CategoryViewModel>> GetCategoryByParentCategoryId(int id);



        public Task<int> SaveCategoryVariance(CategoryVariationRequestModel model);
        public Task<ICollection<CategoryVariationViewModel>> GetAllCategoryVariance();
        public Task<CategoryVariationViewModel> GetCategoryVarianceById(int id);
        public Task<ICollection<CategoryVariationViewModel>> GetAllCategoryVarianceByCategoryId(int id);
        public Task<bool> DeleteCategoryVariance(int id);

        public Task<ICollection<ProductModel>> GetListProducts(int page, int category);
        public Task<ProductModel> GetProductById(int id);
        public Task<int> SaveProduct(ProductModel model);
        public Task<bool> UpdateProduct(ProductModel model);
        public Task<bool> InactiveProduct(int id);
        public Task<ICollection<ProductModel>> GetProductsByCategoryId(int categoryId);
        public Task<ICollection<ProductModel>> GetProductsByName(string name);
        public Task<bool> DeleteProduct(int id);

        public Task<ICollection<ProductVariationModel>> GetProductVariation();
        public Task<ProductVariationModel> SaveProductVariation(ProductVariationModel model);

        public Task<ICollection<VariationValueModel>> GetVariationValues();
        public Task<VariationValueModel> SaveVariationValue(VariationValueModel model);



    }
}
