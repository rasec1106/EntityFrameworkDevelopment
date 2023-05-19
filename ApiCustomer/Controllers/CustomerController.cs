using ApiCustomer.Models;
using ApiCustomer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCustomer.Controllers
{
    [ApiController]
    [Route("/api/customer")]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [Route("/GetCustomers")]
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await customerRepository.GetCustomers();
        }

        [Route("/GetCustomerById/{id}")]
        [HttpGet]
        public async Task<Customer> GetCustomerById(int id)
        {
            return await customerRepository.GetCustomerById(id);
        }

        [Route("/CreateCustomer")]
        [HttpPost]
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            return await customerRepository.CreateCustomer(customer);
        }

        [Route("/UpdateCustomer")]
        [HttpPut]
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await customerRepository.UpdateCustomer(customer);
        }

        [Route("/DeleteCustomer")]
        [HttpDelete]
        public async Task<bool> DeleteCustomer(int id)
        {
            return await customerRepository.DeleteCustomer(id);
        }
    }
}
