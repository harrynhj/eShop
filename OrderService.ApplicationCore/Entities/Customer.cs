using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        [Column("Profile_PIC")]
        public string ProfilePicture { get; set; }


        public ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
