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
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return StatusCode(StatusCodes.Status200OK, await customerRepository.GetCustomers());
        }

        [Route("/GetCustomers/page/{page}/size/{size}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK, await customerRepository.GetCustomers(page, size));
        }

        [Route("/GetCustomerById/{id}")]
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await customerRepository.GetCustomerById(id));
        }

        [Route("/CreateCustomer")]
        [HttpPost]
        // ActionResult is inserted to help customize the kind of response we are sending
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            // We wrap it all into StatusCode
            return StatusCode(StatusCodes.Status201Created, await customerRepository.CreateCustomer(customer));
            
        }

        [Route("/UpdateCustomer")]
        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
        {
            return StatusCode(StatusCodes.Status200OK, await customerRepository.UpdateCustomer(customer));
            /* Another way to do this is */
            return Ok(await customerRepository.UpdateCustomer(customer));
        }

        [Route("/DeleteCustomer")]
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCustomer(int id)
        {
            return StatusCode(StatusCodes.Status200OK, await customerRepository.DeleteCustomer(id));
        }
    }
}
