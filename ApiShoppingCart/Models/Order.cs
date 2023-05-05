namespace ApiShoppingCart.Models
{
    public class Order
    {
        public int orderId { get; set; }
        public int customerId { get; set; }
        public string? customerName { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public decimal amount { get; set;}
        public ICollection<OrderItem>? orderItems { get; set; } // by convention an order has a collection of orderItems
    }
}
