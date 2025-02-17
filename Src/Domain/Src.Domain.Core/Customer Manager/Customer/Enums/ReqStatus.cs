using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Customer_Manager.Customer.Enums
{
    public enum ReqStatus
    {
        [Display(Name = "انجام شده")]
        Success=1,
        [Display(Name = "انجام نشده")]
        Failed,
        [Display(Name = "در حال انتظار")]
        Pending,
        [Display(Name = "در انتظار آمدن متخصص")]
        AwaitingExpert
    }
}
