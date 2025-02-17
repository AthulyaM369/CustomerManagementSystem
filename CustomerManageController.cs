using Microsoft.AspNetCore.Mvc;
using CustomerManageSystem_Service.Interface;

namespace CustomerManagementSystem.Controllers
{
    public class CustomerManageController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerManageController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Customer()
        {
            return View();  
        }
    }
}
