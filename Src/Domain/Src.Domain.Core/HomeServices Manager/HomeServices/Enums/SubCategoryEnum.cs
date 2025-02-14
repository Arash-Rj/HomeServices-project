using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Domain.Core.HomeServices_Manager.HomeServices.Enums
{
    public enum SubCategoryEnum
    {
        [Display(Name ="نظافت مسکونی")]
        ResidentialCleaning,

        [Display(Name = "نظافت اداری")]
        CommercialCleaning,

        [Display(Name = "تعمیر و نگهداری")]
        RepairsAndMaintenance,

        [Display(Name = "خدمات تخصصی")]
        SpecializedServices,

        [Display(Name = "نصب")]
        Installations,

        [Display(Name = "تعمیر")]
        Repairs,

        [Display(Name = "بازسازی داخلی")]
        InteriorRenovation,

        [Display(Name = "بازسازی خارجی")]
        ExteriorRenovation,

        [Display(Name = "سرمایش")]
        CoolingServices,

        [Display(Name = "گرمایش")]
        HeatingServices,

        [Display(Name = "آفت خانگی")]
        ResidentialPestControl,

        [Display(Name = "آفت اداری")]
        CommercialPestControl,

        [Display(Name = "نقاشی داخلی")]
        InteriorlPainting,

        [Display(Name = "نقاشی نما")]
        ExteriorlPainting,

        [Display(Name = "نصب کاغذ دیواری")]
        WallpaperInstallation,

        [Display(Name = "سیستم امنیت هوشمند")]
        SmartSecuritySystem,

        [Display(Name = "قفل در")]
        DoorLockServices,

        [Display(Name = "دوربین امنیتی")]
        SurveillanceCameras,

        [Display(Name = "تعمیر مبلمان")]
        FurnitureRepairs,


        [Display(Name = "نصب کابینت")]
        CabinetMaking,

        [Display(Name = "خدمات کفسازی")]
        FlooringAndWoodRefinishing,

        [Display(Name = "گچ کاری")]
        Plastering,

        [Display(Name = "کاشی کاری")]
        Tiling,

        [Display(Name = "سیمان کاری")]
        CementWork,
    }
}
