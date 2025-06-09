using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.ApplicationCore.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string Product_Image { get; set; }
        public string SKU { get; set; }

        [ForeignKey("CategoryId")]
        public ProductCategory ProductCategory { get; set; }
        public ICollection<ProductVariationValues> ProductVariationValues { get; set; } = new List<ProductVariationValues>();


    }
}
