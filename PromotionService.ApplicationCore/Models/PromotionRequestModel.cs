
using System.ComponentModel.DataAnnotations;

namespace PromotionService.ApplicationCore.Models
{
    public class PromotionRequestModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(5000, MinimumLength = 0)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 100.0)]
        public decimal Discount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
