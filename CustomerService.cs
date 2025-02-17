using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManageSystem_Service.Interface;
using CustomerManageSystem_DTO;
using CustomerManageSystem_DAL;

namespace CustomerManageSystem_Service.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly Dal_Customer _customerDal;

        public CustomerService(Dal_Customer customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task<IEnumerable<CustomerDto>> CustomersData(string mode)
        {
            return await _customerDal.GetCustomersAsync(mode);
        }
        public async Task<string> UpdateCustomerAsync(string Mode, CustomerDto customer)
        {
            return await _customerDal.InsertUpdateCustomerAsync(Mode, customer);
        }
        public async Task<string> DeleteCustomerAsync(string Mode, int CustomerCode)
        {
            return await _customerDal.DeleteCustomerAsync(Mode, CustomerCode);
        }
        public async Task<string> AddCustomerAsync(string Mode, CustomerDto customer)
        {
            return await _customerDal.InsertUpdateCustomerAsync(Mode, customer);
        }
        public async Task<CustomerDto> GetCustomerByCodeAsync(string Mode, int CustomerCode)
        {
            return await _customerDal.GetCustomerByCodeAsync(Mode, CustomerCode);
        }

    }
}
