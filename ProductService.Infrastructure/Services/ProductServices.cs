using ProductService.ApplicationCore.Entities;
using ProductService.ApplicationCore.Models;
using ProductService.ApplicationCore.Repositories;
using ProductService.ApplicationCore.Services;

namespace ProductService.Infrastructure.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ICategoryVariationRepository _categoryVariationRepository;
        private readonly IVariationValueRepository _variationValueRepository;
        private readonly IProductVariationValueRepository _productVariationValueRepository;

        public ProductServices(
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository,
            ICategoryVariationRepository categoryVariationRepository,
            IVariationValueRepository variationValueRepository,
            IProductVariationValueRepository productVariationValueRepository)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _categoryVariationRepository = categoryVariationRepository;
            _variationValueRepository = variationValueRepository;
            _productVariationValueRepository = productVariationValueRepository;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var res = await _productCategoryRepository.DeleteById(id);
            if (res != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCategoryVariance(int id)
        {
            var res = await _categoryVariationRepository.DeleteById(id);
            if (res != null)
            {
                return true;
            }
            return false;
        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryViewModel>> GetAllCategory()
        {
            var categories = await _productCategoryRepository.GetAll();
            var res = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                res.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentId = category.ParentCategoryId ?? -1,
                });

            }
            return res;
        }

        public async Task<ICollection<CategoryVariationViewModel>> GetAllCategoryVariance()
        {
            var categories =  await _categoryVariationRepository.GetAll();
            var res = new List<CategoryVariationViewModel>();
            foreach (var category in categories)
            {
                res.Add(new CategoryVariationViewModel
                {
                    Id = category.Id,
                    VariationName = category.VariationName,
                    CategoryId = category.CategoryId
                });
            }
            return res;
        }

        public async Task<ICollection<CategoryVariationViewModel>> GetAllCategoryVarianceByCategoryId(int id)
        {
            var categories = await _categoryVariationRepository.GetByCategoryId(id);
            var res = new List<CategoryVariationViewModel>();
            foreach (var category in categories)
            {
                res.Add(new CategoryVariationViewModel
                {
                    Id = category.Id,
                    VariationName = category.VariationName,
                    CategoryId = category.CategoryId
                });
            }
            return res;
        }

        public async Task<CategoryViewModel> GetCategoryById(int id)
        {
            var category = await _productCategoryRepository.GetById(id);
            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentCategoryId ?? -1
            };
        }

        public async Task<ICollection<CategoryViewModel>> GetCategoryByParentCategoryId(int id)
        {
            var categories = await _productCategoryRepository.GetByParentCategoryId(id);
            var res = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                res.Add(new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentId = category.ParentCategoryId ?? -1
                });
            }
            return res;

        }

        public async Task<CategoryVariationViewModel> GetCategoryVarianceById(int id)
        {
            var category = await _categoryVariationRepository.GetById(id);
            return new CategoryVariationViewModel
            {
                Id = category.Id,
                VariationName = category.VariationName,
                CategoryId = category.CategoryId
            };
        }

        public async Task<ICollection<ProductModel>> GetListProducts(int page, int category)
        {
            var products = await _productRepository.GetProducts(page, category);
            var res = new List<ProductModel>();
            foreach (var product in products)
            {
                res.Add(new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Qty = product.Qty,
                    ProductImage = product.Product_Image,
                    SKU = product.SKU,
                });
            }
            return res;

        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var product =  await _productRepository.GetById(id);
            if (product != null)
            {
                return new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Qty = product.Qty,
                    ProductImage = product.Product_Image,
                    SKU = product.SKU
                };
            }
            return null;
        }

        public async Task<ICollection<ProductModel>> GetProductsByCategoryId(int categoryId)
        {
            var products = await _productRepository.GetByCategoryId(categoryId);
            if (products == null) { 
                return new List<ProductModel>();
            }
            var res = new List<ProductModel>();
            foreach (var product in products)
            {
                res.Add(new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Qty = product.Qty,
                    ProductImage = product.Product_Image,
                    SKU = product.SKU
                });
            }
            return res;
        }

        public async Task<ICollection<ProductModel>> GetProductsByName(string name)
        {
            var products = await _productRepository.GetByName(name);
            if (products == null)
            {
                return new List<ProductModel>();
            }
            var res = new List<ProductModel>();
            foreach (var product in products)
            {
                res.Add(new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Price = product.Price,
                    Qty = product.Qty,
                    ProductImage = product.Product_Image,
                    SKU = product.SKU
                });
            }
            return res;
        }

        public async Task<ICollection<ProductVariationModel>> GetProductVariation()
        {
            var vals = await _productVariationValueRepository.GetAll();
            var res = new List<ProductVariationModel>();
            foreach (var val in vals)
            {
                res.Add(new ProductVariationModel
                {
                    ProdutId = val.ProductId,
                    VariationId = val.VariationValueId
                });
            }
            return res;
        }

        public async Task<ICollection<VariationValueModel>> GetVariationValues()
        {
            var vals = await _variationValueRepository.GetAll();
            var res = new List<VariationValueModel>();
            foreach (var val in vals)
            {
                res.Add(new VariationValueModel
                {
                    Id = val.Id,
                    VariationId = val.VariationId,
                    Value = val.Value
                });
            }
            return res;
        }

        public async Task<bool> InactiveProduct(int id)
        {
            return await _productRepository.InactiveProduct(id);
        }

        public async Task<int> SaveCategory(CategoryRequestModel model)
        {
            ProductCategory productCategory = new ProductCategory
            {
                Name = model.Name,
                ParentCategoryId = model.ParentCategoryId == -1 ? null : model.ParentCategoryId
            };
            var result = await _productCategoryRepository.Insert(productCategory);
            if (result != null)
            {
                return result.Id;
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> SaveCategoryVariance(CategoryVariationRequestModel model)
        {
            var res = await _categoryVariationRepository.Insert(new CategoryVariation
            {
                VariationName = model.VariationName,
                CategoryId = model.CategoryId
            });
            if (res != null)
            {
                return res.Id;
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> SaveProduct(ProductModel model)
        {
            Product value = new Product
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Qty = model.Qty,
                Product_Image = model.ProductImage,
                SKU = model.SKU
            };
            var res = _productRepository.Insert(value);
            if (res != null)
            {
                return res.Id;
            }
            else
            {
                return -1;
            }
        }

        public async Task<ProductVariationModel> SaveProductVariation(ProductVariationModel model)
        {
            ProductVariationValues val = new ProductVariationValues
            {
                ProductId = model.ProdutId,
                VariationValueId = model.VariationId
            };
            var res = await _productVariationValueRepository.Insert(val);
            if (res != null)
            {
                return new ProductVariationModel
                {
                    ProdutId = res.ProductId,
                    VariationId = res.VariationValueId
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<VariationValueModel> SaveVariationValue(VariationValueModel model)
        {
            VariationValue value = new VariationValue
            {
                VariationId = model.VariationId,
                Value = model.Value
            };
            var res = await _variationValueRepository.Insert(value);
            if (res != null)
            {
                return new VariationValueModel
                {
                    Id = res.Id,
                    VariationId = res.VariationId,
                    Value = res.Value
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateProduct(ProductModel model)
        {
            Product product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Price = model.Price,
                Qty = model.Qty,
                Product_Image = model.ProductImage,
                SKU = model.SKU
            };

            var res = _productRepository.Update(product);
            if (res != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
