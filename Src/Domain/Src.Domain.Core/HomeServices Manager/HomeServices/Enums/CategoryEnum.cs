using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Enums
{
    public enum CategoryEnum
    {
        [Display(Name ="نظافت")]
        CleaningServices,

        [Display(Name ="لوله کشی")]
        PlumbingServices,

        [Display(Name ="خدمات برق")]
        ElectricalServices,

        [Display(Name ="باز سازی منزل")]
        HomeRenovation,

        [Display(Name ="تهویه هوا")]
        HVAC,  //Heating, Ventilation, and Air Conditioning

        [Display(Name ="کنترل آفت")]
        PestControlServices,

        [Display(Name ="نقاشی")]
        PaintingServices,

        [Display(Name ="تعمیر لوازم خانگی")]
        ApplianceRepairServices,

        [Display(Name ="امنیت")]
        HomeSecurityServices,

        [Display(Name = "نجاری")]
        CarpentryAndWoodwork,

        [Display(Name = "بنایی")]
        Masonry
    }
}
