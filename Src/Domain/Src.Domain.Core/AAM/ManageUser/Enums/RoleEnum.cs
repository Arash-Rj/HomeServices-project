using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.AAM.ManageUser.Enums
{
    public enum RoleEnum
    {
        [Display(Name ="مشتری")]
        Customer,
        [Display(Name = "کارشناس")]
        Expert,
        [Display(Name = "ادمین")]
        Admin
    }
}
