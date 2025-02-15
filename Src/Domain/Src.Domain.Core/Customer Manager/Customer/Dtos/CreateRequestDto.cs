using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Dtos
{
    public class CreateRequestDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public DateOnly ExecutionDate { get; set; }
        public TimeOnly ExecutionTime { get; set; }
        public int CustomerId { get; set; }
        public int HomeServiceId { get; set; }
        public List<Image> Images { get; set; }
    }
}
