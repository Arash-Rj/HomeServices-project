using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Enums;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Entities
{
    public class AppRequest
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string HomeServiceTitle { get; set; }
        public bool IsActive { get; set; }
        public DateOnly RequestDate { get; set; }
        public DateOnly ExecutionDate { get; set; }
        public TimeOnly ExecutionTime { get; set; }
        public ReqStatus Status { get; set; }
        public int CustomerId { get; set; }
        public AppCustomer Customer { get; set; }
        public List<Proposal> Proposals { get; set; }   
        public List<Image> Images { get; set; }
    }
}
