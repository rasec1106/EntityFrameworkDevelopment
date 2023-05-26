namespace Test_Practice02_01.Models
{
    public class ShipDocumentDetail
    {
        public int shipDocumentDetailId { get; set; }
        public int productId { get; set; }
        public string? productName { get; set; }
        public decimal? unitPrice { get; set; }
        public int quantity { get; set; }
        public decimal subTotal { get; set; }
        public int shipDocumentId { get; set; }
        public ShipDocument shipDocument { get; set; }

    }
}
