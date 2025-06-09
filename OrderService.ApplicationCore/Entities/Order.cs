using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.ApplicationCore.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Column("Order_Date")]
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName{ get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }
        public decimal BillAmount { get; set; }
        [Column("Order_Status")]
        public string OrderStatus { get; set; }


        [ForeignKey("PaymentMethodId")]
        public PaymentMethod PaymentMethod { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
