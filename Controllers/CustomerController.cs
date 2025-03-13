using API_CoffeQ.DTOs;
using API_CoffeQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_CoffeQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomersRepository customersRepository):ControllerBase
    {
        private readonly ICustomersRepository _customersRepository = customersRepository;

        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> GetCustomers()
        {
            var customers = await _customersRepository.GetCustomers();
            return Ok(customers);
        }
        [HttpGet("{customerid}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomer(string customerid)
        {
            var customer = await _customersRepository.GetCustomer(customerid);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> AddCustomer(CustomerDTO customer)
        {
            var newCustomer = await _customersRepository.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = newCustomer.IdCustomer }, newCustomer);
        }
        [HttpPut]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(CustomerDTO customer)
        {
            var newCustomer = await _customersRepository.UpdateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = newCustomer.IdCustomer }, newCustomer);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDTO>> DeleteCustomer(int id)
        {
            var customer = await _customersRepository.DeleteCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

    }
}
