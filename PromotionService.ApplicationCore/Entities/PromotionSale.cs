using System.ComponentModel.DataAnnotations.Schema;


namespace PromotionService.ApplicationCore.Entities
{
    public class PromotionSale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Discount { get; set; }
        [Column("Start_Date")]
        public DateTime StartDate { get; set; }
        [Column("End_Date")]
        public DateTime EndDate { get; set; }

    }
}
