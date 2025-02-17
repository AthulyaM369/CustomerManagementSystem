using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerManageSystem_DTO;

namespace CustomerManageSystem_Service.Interface
{
    public interface ICustomerService
    {
            Task<IEnumerable<CustomerDto>> CustomersData(string mode);
        Task<string> UpdateCustomerAsync(string Mode, CustomerDto customer);
        Task<string> DeleteCustomerAsync(string Mode, int customerCode);
        Task<string> AddCustomerAsync(string Mode, CustomerDto customer);
        Task<CustomerDto> GetCustomerByCodeAsync(string Mode, int customerCode);
    }
}
