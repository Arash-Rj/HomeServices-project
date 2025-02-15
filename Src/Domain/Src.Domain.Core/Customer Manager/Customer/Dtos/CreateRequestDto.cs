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
    public class CreateRequestDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        [MaxLength(10)]
        public string ExecutionDate { get; set; }
        [MaxLength(5)]
        public string ExecutionTime { get; set; }
        public int CustomerId { get; set; }
        public int HomeServiceId { get; set; }
        public List<Image> Images { get; set; }
    }
}
