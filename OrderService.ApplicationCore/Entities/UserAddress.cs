using System.ComponentModel.DataAnnotations.Schema;

namespace OrderService.ApplicationCore.Entities
{
    [Table("User_Address")]
    public class UserAddress
    {
        public int Id { get; set; }
        [Column("Customer_Id")]
        public int CustomerId { get; set; }
        [Column("Address_Id")]
        public int AddressId { get; set; }
        public bool IsDefaultAddress { get; set; }


        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }

        }
}
