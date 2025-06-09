using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.ApplicationCore.Entities
{
    [Table("Shopping_Cart_Item")]
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        [Column("Cart_Id")]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CartId")]
        public ShoppingCart ShoppingCart { get; set; }
    }
}
