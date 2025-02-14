using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.Expert_Manager.Expert.Enums
{
    public enum ProposalStatus
    {
        [Display(Name = "پیشنهاد شما قبول شده.")]
        Accepted,
        [Display(Name = ".در انتظار تصمیم مشتری")]
        Pending,
        [Display(Name = "پیشنهاد شما رد شد.")]
        Rejected
    }
}
