using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Entities
{
    public class FeedBack
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public FeedBackStatus Status { get; set; }
        public int Score { get; set; }
        public int ExpertId { get; set; }
        public AppExpert Expert { get; set; }
        public int CustomerId { get; set; }
        public AppCustomer Customer { get; set; }
    }
}
