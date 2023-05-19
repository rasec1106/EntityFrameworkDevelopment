using ApiCustomer.Models;
using ApiCustomer.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;

namespace ApiCustomer.Repository
{
    public class CustomerSQLRepository : ICustomerRepository
    {
        private ApiCustomerContext dbContext;
        private ILogger<CustomerSQLRepository> logger;

        public CustomerSQLRepository(ApiCustomerContext dbContext, ILogger<CustomerSQLRepository> logger)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await this.dbContext.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            logger.LogInformation("Fetch customer in the database with id = " + id.ToString());
            var customer = await dbContext.Customers.Where(c => c.CustomerId == id).FirstOrDefaultAsync();
            if (customer == null)
            {
                throw new NotFoundException("Customer not found with id=" + id.ToString());
            }
            logger.LogInformation("Customer with id=" + customer.CustomerId.ToString());
            return customer;
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
