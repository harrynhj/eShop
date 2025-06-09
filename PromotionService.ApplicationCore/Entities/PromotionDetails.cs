using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionService.ApplicationCore.Entities
{
    [Table("Promotion_Details")]
    public class PromotionDetails
    {
        public int Id { get; set; }

        [Column("Promotion_Id")]
        public int PromotionId { get; set; }
        [Column("Product_Category_Id")]
        public int ProductCategoryId { get; set; }
        [Column("Product_Category_Name")]
        public string ProductCategoryName { get; set; }

        [ForeignKey("PromotionId")]
        public PromotionSale PromotionSale { get; set; }
    }
}
