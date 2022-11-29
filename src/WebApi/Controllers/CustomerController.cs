using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository= customerRepository;
        }

        private readonly ICustomerRepository _customerRepository;

        [HttpGet("{id:long}")]   
        public async Task<ActionResult<Customer>> GetCustomerAsync([FromRoute] long id)
        {
            var result = await _customerRepository.FindAsync(id);

            if(result== null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("")]   
        public async Task<ActionResult<long>> CreateCustomerAsync([FromBody] Customer customer)
        {
            bool result = await _customerRepository.TryAddAsync(customer);

            if (result)
                return Ok(customer.Id);
            else
                return Conflict();
        }
    }
}