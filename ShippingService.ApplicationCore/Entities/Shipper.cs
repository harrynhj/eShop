using System.ComponentModel.DataAnnotations.Schema;


namespace ShippingService.ApplicationCore.Entities
{
    public class Shipper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Column("Contact_Person")]
        public string ContactPerson { get; set; }


        public ICollection<ShipperRegion> ShipperRegions { get; set; } = new List<ShipperRegion>();
        public ICollection<ShippingDetail> ShippingDetails { get; set; } = new List<ShippingDetail>();

    }
}
