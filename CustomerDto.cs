using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManageSystem_DTO
{
    public class CustomerDto
    {
        public int CustomerCode { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? GeoLocation { get; set; }
    }
}
