using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.ApplicationCore.Entities
{
    [Table("Variation_Value")]
    public class VariationValue
    {
        public int Id { get; set; }
        [Column("Variation_Id")]
        public int VariationId {get; set;}
        public string Value { get; set; }

        [ForeignKey("VariationId")]
        public CategoryVariation CategoryVariation { get; set; }
        public ICollection<ProductVariationValues> ProductVariationValues { get; set; } = new List<ProductVariationValues>();
    }
}
