using ApiCustomer.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiCustomer.Repository
{
    public class CustomerSQLRepository : ICustomerRepository
    {
        private ApiCustomerContext dbContext;

        public CustomerSQLRepository(ApiCustomerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await this.dbContext.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await this.dbContext.Customers.Where(customer => customer.CustomerId == id).FirstOrDefaultAsync();
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            this.dbContext.Customers.Add(customer);
            await this.dbContext.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            this.dbContext.Customers.Update(customer);
            await this.dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var result = await this.dbContext.Customers.FirstOrDefaultAsync(customer => customer.CustomerId == id);
            if(result != null)
            {
                this.dbContext.Customers.Remove(result);
                await this.dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
