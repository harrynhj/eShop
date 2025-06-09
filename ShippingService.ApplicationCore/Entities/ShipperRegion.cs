using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingService.ApplicationCore.Entities
{
    [Table("Shipper_Region")]
    public class ShipperRegion
    {
        [Column("Region_Id")]
        public int RegionId { get; set; }
        [Column("Shipper_Id")]
        public int ShipperId { get; set; }
        public bool Active { get; set; }

        [ForeignKey(nameof(RegionId))]
        public Region Region { get; set; }
        [ForeignKey(nameof(ShipperId))]
        public Shipper Shipper { get; set; }


    }
}
