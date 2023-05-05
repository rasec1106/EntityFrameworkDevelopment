namespace ApiShoppingCart.Models
{
    public class OrderItem
    {
        public int orderItemId { get; set; }
        public int productId { get; set; }
        public string? customer { get; set; }

    }
}
