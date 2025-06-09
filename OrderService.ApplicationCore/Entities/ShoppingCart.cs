using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.ApplicationCore.Entities
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }


        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
