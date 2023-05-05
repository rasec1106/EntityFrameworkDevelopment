using ApiShoppingCart.Models;
using ApiShoppingCart.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiShoppingCart.Controllers
{
    [Route("/api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public ICartRepository cartRepository;
        public CartController(ICartRepository cartRepository) 
        {
            this.cartRepository = cartRepository;
        }

        [Route("/placeOrder")]
        [HttpPost]
        public async Task<bool> placeOrder(Order order)
        {
            return await this.cartRepository.placeOrder(order);
        }
    }
}
