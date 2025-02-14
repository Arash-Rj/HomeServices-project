using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.Customer_Manager.Customer;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using Src.Domain.Core.Payment_Manager.Payment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Entities
{
    public class AppCustomer : User
    {
        public List<AppRequest>? Requests { get; set; }
        public List<FeedBack>? FeedBacks { get; set; }
    }
}
