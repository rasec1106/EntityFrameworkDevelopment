using Test_Practice01_01.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Test_Practice01_01.Repository
{
    public class ProviderSQLRepository : IProviderRepository
    {
        private TestPractice01Context dbContext;

        public ProviderSQLRepository(TestPractice01Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MyProvider> CreateProvider(MyProvider provider)
        {
            this.dbContext.MyProviders.Add(provider);
            await this.dbContext.SaveChangesAsync();
            return provider;
        }

        public async Task<bool> DeleteProvider(int id)
        {
            var result = await this.dbContext.MyProviders.FirstOrDefaultAsync(provider => provider.ProviderId == id);
            if (result != null)
            {
                this.dbContext.MyProviders.Remove(result);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<MyProvider> GetProviderById(int id)
        {
            return await this.dbContext.MyProviders.Where(provider => provider.ProviderId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MyProvider>> GetProviders()
        {
            return await this.dbContext.MyProviders.ToListAsync();
        }

        public async Task<MyProvider> UpdateProvider(MyProvider provider)
        {
            this.dbContext.MyProviders.Update(provider);
            await this.dbContext.SaveChangesAsync();
            return provider;
        }
    }
}
