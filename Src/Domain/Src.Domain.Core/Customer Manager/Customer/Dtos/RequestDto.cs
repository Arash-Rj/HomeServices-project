using Src.Domain.Core.Customer_Manager.Customer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Dtos
{
    public class RequestDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }
        public DateOnly RequestDate { get; set; }
        public string CustomerName { get; set; }
        public string HomeServiceName { get; set; }
    }
}
