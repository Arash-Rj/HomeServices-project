using Microsoft.AspNetCore.Identity;
using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using Src.Domain.Core.Payment_Manager.Payment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.AAM.ManageUser.Entities
{
    public class User: IdentityUser<int>
    {
        //public string? Biography { get; set; }
        public string? CardNumber { get; set; }
        public float Balance { get; set; }   
        public ProvinceEnum Province { get; set; }
        public DateTime RegisterDate { get; set; }
        //public bool IsActive { get; set; }
        public string? ImagePath { get; set; }
        public List<AppPayment>? Payments { get; set; }
    }
}
