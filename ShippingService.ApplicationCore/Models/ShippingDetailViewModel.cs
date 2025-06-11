namespace ShippingService.ApplicationCore.Models
{
    public class ShippingDetailViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ShippingStatus { get; set; }
        public string TrackingNumber { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public string Contact_Person { get; set; }
    }
}
