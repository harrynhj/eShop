using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.ApplicationCore.Entities
{
    [Table("Product_variation_values")]
    public class ProductVariationValues
    {
        [Column("Product_Id")]
        public int ProductId { get; set; }

        [Column("Variation_value_id")]
        public int VariationValueId { get; set; }

        public Product Product { get; set; }

        public VariationValue VariationValue { get; set; }
    }
}
