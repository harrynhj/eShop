using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewService.ApplicationCore.Models
{
    public class CustomerReviewViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int Rating { get; set; } = 0;
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
