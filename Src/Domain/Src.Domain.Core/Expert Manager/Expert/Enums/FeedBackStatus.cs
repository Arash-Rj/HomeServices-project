using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Enums
{
    public enum FeedBackStatus
    {
        [Display(Name = "بازخورد قبول شده.")]
        Accepted=1,
        [Display(Name = ".در انتظار تایید ادمین")]
        Pending,
        [Display(Name = "بازخورد رد شده.")]
        Rejected
    }
}
