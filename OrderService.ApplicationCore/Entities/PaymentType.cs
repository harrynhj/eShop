using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.ApplicationCore.Entities
{
    [Table("Payment_Type")]
    public class PaymentType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();
    }
}
