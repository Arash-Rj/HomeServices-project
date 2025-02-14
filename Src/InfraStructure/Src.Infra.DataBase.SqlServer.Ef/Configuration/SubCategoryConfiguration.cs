using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.AppExperts).WithMany(e => e.Specialties);

             

            //builder.HasData(new List<SubCategory>()
            //{
            //    new SubCategory { Id=1 , Title=SubCategoryEnum.ResidentialCleaning , CategoryId=0 , ImagePath= },
            //     new SubCategory { Id=2 , Title=SubCategoryEnum.CommercialCleaning , CategoryId=0 , ImagePath= },
            //      new SubCategory { Id=3 , Title=SubCategoryEnum.RepairsAndMaintenance , CategoryId=1 , ImagePath= },
            //       new SubCategory { Id=4 , Title=SubCategoryEnum.SpecializedServices , CategoryId=1 , ImagePath= },
            //       new SubCategory { Id= 5, Title=SubCategoryEnum.Installations , CategoryId=2 , ImagePath= },
            //        new SubCategory { Id= 6, Title=SubCategoryEnum.Repairs , CategoryId=2 , ImagePath= },
            //         new SubCategory { Id= 7, Title=SubCategoryEnum.InteriorRenovation , CategoryId=3 , ImagePath= },
            //          new SubCategory { Id= 8, Title=SubCategoryEnum.ExteriorRenovation , CategoryId=3 , ImagePath= },
            //           new SubCategory { Id= 9, Title=SubCategoryEnum.CoolingServices , CategoryId=4 , ImagePath= },
            //            new SubCategory { Id= 10, Title=SubCategoryEnum.HeatingServices, CategoryId=4 , ImagePath= },
            //             new SubCategory { Id= 11, Title=SubCategoryEnum.ResidentialPestControl , CategoryId=5 , ImagePath= },
            //            new SubCategory { Id= 12, Title=SubCategoryEnum.CommercialPestControl , CategoryId=5 , ImagePath= },
            //           new SubCategory { Id=13 , Title=SubCategoryEnum.InteriorlPainting , CategoryId=6 , ImagePath= },
            //          new SubCategory { Id=14 , Title=SubCategoryEnum.ExteriorlPainting , CategoryId=6 , ImagePath= },
            //         new SubCategory { Id=15 , Title=SubCategoryEnum.WallpaperInstallation, CategoryId=6 , ImagePath= },
            //        new SubCategory { Id=16 , Title=SubCategoryEnum.SmartSecuritySystem , CategoryId=8 , ImagePath= },
            //       new SubCategory { Id= 17, Title=SubCategoryEnum.DoorLockServices , CategoryId=8 , ImagePath= },
            //      new SubCategory { Id= 18, Title=SubCategoryEnum.SurveillanceCameras , CategoryId=8 , ImagePath= },
            //     new SubCategory { Id=19 , Title=SubCategoryEnum.FurnitureRepairs , CategoryId=7 , ImagePath= },
            //    new SubCategory { Id=20 , Title=SubCategoryEnum.CabinetMaking , CategoryId=9 , ImagePath= },
            //     new SubCategory { Id=21 , Title=SubCategoryEnum.FlooringAndWoodRefinishing , CategoryId=9 , ImagePath= },
            //      new SubCategory { Id=21 , Title=SubCategoryEnum.Plastering , CategoryId=10 , ImagePath= },
            //       new SubCategory { Id=21 , Title=SubCategoryEnum.Tiling , CategoryId=10 , ImagePath= },
            //        new SubCategory { Id=21 , Title=SubCategoryEnum.CementWork , CategoryId=10 , ImagePath= },
            //}
        }
    }
}
