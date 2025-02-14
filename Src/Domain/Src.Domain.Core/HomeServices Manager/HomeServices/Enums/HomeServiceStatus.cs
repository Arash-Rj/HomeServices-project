using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Enums
{
    public enum HomeServiceStatus
    {
        [Display(Name = "فعال")]
        Active =1,
        [Display(Name = "غیرفعال")]
        Inactive =0,
    }
}
