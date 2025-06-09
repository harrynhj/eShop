using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.ApplicationCore.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        [Column("Payment_Type_Id")]
        public int PaymentTypeId { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public string Expiry { get; set; }
        public bool IsDefault { get; set; }




        [ForeignKey("PaymentTypeId")]
        public PaymentType PaymentType { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
