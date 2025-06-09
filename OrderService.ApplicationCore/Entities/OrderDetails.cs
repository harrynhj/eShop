using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.ApplicationCore.Entities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Column("Order_Id")]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Column("Product_Id")]
        public int ProductId { get; set; }
        [Column("Product_Name")]
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public Order Order { get; set; }

    }
}
