using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.ApplicationCore.Entities
{
    [Table("Product_Category")]
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("Parent_Category_Id")]
        public int? ParentCategoryId { get; set; }


        [ForeignKey("ParentCategoryId")]
        public ProductCategory ParentCategory { get; set; }

        public ICollection<ProductCategory> SubCategories { get; set; } = new List<ProductCategory>();
        public ICollection<CategoryVariation> CategoryVariation { get; set; } = new List<CategoryVariation>();

    }

}
