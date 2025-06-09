using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingService.ApplicationCore.Entities
{
    [Table("Shipping_Details")]
    public class ShippingDetail
    {
        public int Id { get; set; }
        [Column("Order_Id")]
        public int OrderId { get; set; }
        [Column("Shipper_Id")]
        public int ShipperId { get; set; }
        [Column("Shipping_Status")]
        public string ShippingStatus { get; set; }
        [Column("Shipping_Number")]
        public string TrackingNumber { get; set; }

        [ForeignKey("ShipperId")]
        public Shipper Shipper { get; set; }
    }
}
