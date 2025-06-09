using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewService.ApplicationCore.Entities
{
    [Table("Customer_Review")]
    public class CustomerReview
    {
        public int Id { get; set; }
        [Column("Customer_Id")]
        public int CustomerId { get; set; }
        [Column("Customer_Name")]
        public string CustomerName { get; set; }
        [Column("Order_Id")]
        public int OrderId { get; set; }
        [Column("Order_Date")]
        public DateTime OrderDate { get; set; }
        [Column("Product_Id")]
        public int ProductId { get; set; }
        [Column("Product_Name")]
        public string ProductName { get; set; }
        [Column("Rating_value")]
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        [Column("Review_Date")]
        public DateTime ReviewDate { get; set; }
    }
}
