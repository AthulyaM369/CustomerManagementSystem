using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CustomerManageSystem_DTO;
using CustomerManageSystem_Service.Interface;

namespace CustomerManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers([FromQuery] string mode)
        {
            var customers = await _customerService.CustomersData(mode);
            return Ok(customers);
        }


        [HttpPut("{customerCode}")]
        public async Task<IActionResult> UpdateCustomer(string Mode, [FromBody] CustomerDto customer)
        {
            var isUpdated = await _customerService.UpdateCustomerAsync(Mode, customer);
            return Ok(isUpdated);
        }

        [HttpDelete("{customerCode}")]
        public async Task<IActionResult> DeleteCustomer(string Mode,int customerCode)
        {
            try
            {
                var result = await _customerService.DeleteCustomerAsync(Mode, customerCode);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(string Mode, [FromBody] CustomerDto customer)
        {

            var result = await _customerService.UpdateCustomerAsync(Mode, customer);
            return Ok(result);
        }

        [HttpGet("{customerCode}")]
        public async Task<IActionResult> GetCustomerByCode(string Mode, int customerCode)
        {
            var customer = await _customerService.GetCustomerByCodeAsync(Mode, customerCode);           
            return Ok(customer);
        }


    }
}
