using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.ApplicationCore.Entities
{
    [Table("Category_Variation")]
    public class CategoryVariation
    {
        public int Id { get; set; }
        [Column("Category_Id")]
        public int CategoryId { get; set; }
        [Column("Variation_Name")]
        public string VariationName { get; set; }


        [ForeignKey("CategoryId")]
        public ProductCategory ProductCategory { get; set; }
        public ICollection<VariationValue> VariationValues { get; set; } = new List<VariationValue>();

    }
}
