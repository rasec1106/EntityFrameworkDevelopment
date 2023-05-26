namespace Test_Practice02_01.Models
{
    public class ShipDocument
    {
        public int shipDocumentId { get; set; }
        public int customerId { get; set; }
        public string? customerName { get; set; }
        public string? shipAddress { get; set; }
        public string? customerRuc { get; set; }
        public int driverId { get; set; }
        public string? driverName { get; set; }
        public DateTime? shipDate { get; set; }
        public int totalBoxes { get; set; }
        public int totalWeight { get; set; }
        public decimal totalAmount { get; set; }
        public ICollection<ShipDocumentDetail> shipDocumentDetails { get;set; }

    }
}
