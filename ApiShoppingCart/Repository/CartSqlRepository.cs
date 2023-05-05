using ApiShoppingCart.DbContexts;
using ApiShoppingCart.Models;
using System;

namespace ApiShoppingCart.Repository
{
    public class CartSqlRepository : ICartRepository
    {
        private AppDBContext dbContext;
        public CartSqlRepository(AppDBContext dbContext) {
            this.dbContext = dbContext;
        }
        public async Task<bool> placeOrder(Order order)
        {

            try
            {
                dbContext.orders.Add(order);
                // SaveChanges hace la trx de manera automatica
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
            //inicio el contexto de la transacction
            var trxCart = dbContext.Database.BeginTransaction();
            try
            {
                //grabando la cabecera (Orders)
                dbContext.orders.Add(order);
                await dbContext.SaveChangesAsync();

                //grabar el detalle (cantidad items)
                foreach (var oi in order.orderItems)
                {
                    oi.orderId = order.orderId;
                }
                await dbContext.SaveChangesAsync();
                trxCart.Commit();
                return true;
            }
            catch
            {
                //fallo el proceso de grabado => se deshace los cambios 
                trxCart.Rollback();
                return false;
            }
        }
    }
}
