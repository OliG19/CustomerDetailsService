using CustomerDetailsService.DAL;
using CustomerDetailsService.Models.Domains;
using CustomerDetailsService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerDetailsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<DomainCustomer> GetAll()
        {
            return  _customerService.GetAll().ToList();
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<DomainCustomer>> Get(string name)
        {
            if (IsNameInvalid(name))
            {
                return BadRequest();
            }

            return await _customerService.GetCustomerByName(name);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] DomainCustomer customer)
        {
            if (IsNameInvalid(customer.Name))
            {
                return BadRequest();
            }

            await _customerService.SaveAsync(customer);

            return NoContent();
        }

        [HttpDelete]
        [Route("{name}")]
        public async Task<ActionResult> Delete(string name)
        {
            if (IsNameInvalid(name))
            {
                return BadRequest();
            }

            await _customerService.DeleteAsync(name);

            return NoContent();

        }

        private bool IsNameInvalid(string name)
            => name == null || Regex.IsMatch(name, @"\d");
    }
}
