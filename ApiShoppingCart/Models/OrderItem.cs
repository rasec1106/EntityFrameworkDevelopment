﻿namespace ApiShoppingCart.Models
{
    public class OrderItem
    {
        public int orderItemId { get; set; }
        public int productId { get; set; }
        public string? productName { get; set; }
        public decimal unitPrice { get; set; }
        public decimal quantity { get; set; }
        public decimal discount { get; set; }
        public decimal subTotal { get; set; }
    }
}
