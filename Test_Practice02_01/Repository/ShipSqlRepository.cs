using Test_Practice02_01.DbContexts;
using Test_Practice02_01.Models;
using System;
namespace Test_Practice02_01.Repository
{
    public class ShipSqlRepository : IShipRepository
    {
        private AppDbContext dbContext;
        public ShipSqlRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> createShipDocument(ShipDocument shipDocument)
        {
            try
            {
                dbContext.shipDocuments.Add(shipDocument);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
