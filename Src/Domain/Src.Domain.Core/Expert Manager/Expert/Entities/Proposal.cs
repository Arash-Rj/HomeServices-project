using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Entities
{
    public class Proposal
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public DateTime ProposalDate { get; set; }
        public DateOnly DueDate { get; set; }
        public TimeOnly DueTime { get; set; }
        public ProposalStatus Status { get; set; }
        public int RequestId { get; set; }
        public AppRequest Request { get; set; }
        public int ExpertId { get; set; }
        public AppExpert? Expert { get; set; } 
    }
}
