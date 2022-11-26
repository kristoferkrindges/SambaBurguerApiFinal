using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SambaBurguer.Models;
using SambaBurguer.Repository.Interfaces;

namespace SambaBurguer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository) {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers() {
            List<Customer> customers = await _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetForId(int id)
        {
            Customer customers = await _customerRepository.GetForId(id);
            return Ok(customers);
        }
        [HttpPost]
        public async Task<ActionResult<Customer>> Add([FromBody] Customer customer) {
            Customer newCustomer = await _customerRepository.Add(customer);
            return Ok(newCustomer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Update([FromBody] Customer customer, int id)
        {
            customer.Id = id;
            Customer newCustomer = await _customerRepository.Update(customer, id);
            return Ok(newCustomer);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            bool del = await _customerRepository.Delete(id);
            return Ok(del);
        }
    }
}
