using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Dtos
{
    public class RequestInfoDto
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? HomeServiceName { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }
        public DateOnly ExecutionDate { get; set; }
        public TimeOnly ExecutionTime { get; set; }
        public ReqStatus Status { get; set; }
        public List<Image> Images { get; set; }
    }
}
