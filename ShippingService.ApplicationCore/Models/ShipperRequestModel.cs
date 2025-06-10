using System.ComponentModel.DataAnnotations;

namespace ShippingService.ApplicationCore.Models
{
    public class ShipperRequestModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Name { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string? Email { get; set; }

        [RegularExpression(@"^\d{10}$")]
        public string? Phone { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string ContactPerson { get; set; }
    }
}