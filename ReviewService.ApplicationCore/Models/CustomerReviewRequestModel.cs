using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewService.ApplicationCore.Models
{
    public class CustomerReviewRequestModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }

        public string? OrderId { get; set; }

        public string? ProductId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [Required]
        [Range(1.0, 5.0)]
        public double RatingValue { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; }
    }
}
