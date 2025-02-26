using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
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

            builder.Property(x => x.Name).HasMaxLength(30);

            builder.HasData(new List<SubCategory>()
            {
                new SubCategory { Id=1 , Name="نظافت مسکونی" , CategoryId=4 /*, ImagePath=*/ },
                 new SubCategory { Id=2 , Name="نظافت اداری" , CategoryId=4 /*, ImagePath=*/ },
                  new SubCategory { Id=3 , Name="تعمیرات و نگهدرای" , CategoryId=3 /*, ImagePath=*/ },
                   new SubCategory { Id=4 , Name="سرویس برق خانه" , CategoryId=1 /*, ImagePath=*/ },
                   new SubCategory { Id= 5, Name="نصب" , CategoryId=8 /*, ImagePath=*/ },
                    new SubCategory { Id= 6, Name="تعمیرات" , CategoryId=8 /*, ImagePath=*/ },
                     new SubCategory { Id= 7, Name="دکوراسیون داخلی" , CategoryId=6 /*, ImagePath=*/ },
                      new SubCategory { Id= 8, Name="نوسازی نمای ساختمان" , CategoryId=6 /*, ImagePath=*/ },
                       new SubCategory { Id= 9, Name="سیستم سرمایش" , CategoryId=7 /*, ImagePath=*/ },
                        new SubCategory { Id= 10, Name="سیستم گرمایش", CategoryId=7 /*, ImagePath=*/ },
                         new SubCategory { Id= 11, Name="کنترل افت مسکونی" , CategoryId=5 /*, ImagePath=*/ },
                        new SubCategory { Id= 12, Name="کنترل افت اداری" , CategoryId=5 /*, ImagePath=*/ },
                       new SubCategory { Id=13 , Name="نقاشی داخل ساختمان" , CategoryId=2 /*, ImagePath=*/ },
                      new SubCategory { Id=14 , Name="نقاشی نما" , CategoryId=2 /*, ImagePath=*/ },
                     new SubCategory { Id=15 , Name="کاغذ دیواری", CategoryId=2 /*, ImagePath=*/ },
                    new SubCategory { Id=16 , Name="سیستم امنیتی هوشمند" , CategoryId=9 /*, ImagePath=*/ },
                   new SubCategory { Id= 17, Name="سرویس قفل در" , CategoryId=9 /*, ImagePath=*/ },
                  new SubCategory { Id= 18, Name="دوربین امنیتی" , CategoryId=9 /*, ImagePath=*/ },
                 new SubCategory { Id=19 , Name="تعمیرات مبلمان" , CategoryId=3 /*, ImagePath=*/ },
                new SubCategory { Id=20 , Name="کابینت سازی" , CategoryId=10 /*, ImagePath=*/ },
                 new SubCategory { Id=21 , Name="کف سازی و صافکاری چوب" , CategoryId=10 /*, ImagePath=*/ },
                  new SubCategory { Id=22 , Name="گچ کاری" , CategoryId=11 /*, ImagePath=*/ },
                   new SubCategory { Id=23 , Name="کاشی کاری" , CategoryId=11 /*, ImagePath=*/ },
                    new SubCategory { Id=24 , Name="سیمان کاری" , CategoryId=11 /*, ImagePath=*/ },
                     new SubCategory { Id=25 , Name="سرویس برق اضظراری" , CategoryId=1 /*, ImagePath=*/ },
                       new SubCategory { Id=26 , Name="سرویس برق اداری" , CategoryId=1 /*, ImagePath=*/ },
            });
        }
    }
}
