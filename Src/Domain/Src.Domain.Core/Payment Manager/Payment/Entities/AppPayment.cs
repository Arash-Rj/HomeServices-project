using Src.Domain.Core.AAM.ManageAdmin.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Payment_Manager.Payment.Entities
{
    public class AppPayment
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public float Amount { get; set; }
        public int CustomerId { get; set; }
        public AppCustomer Customer { get; set; }
        public int ExpertId { get; set; }
        public AppExpert Expert { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int RequestId { get; set; }
        public AppRequest Request { get; set; }
    }
}
