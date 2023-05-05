using ApiShoppingCart.Models;
namespace ApiShoppingCart.Repository
{
    public interface ICartRepository
    {
        public Task<bool> placeOrder(Order order);
    }
}
