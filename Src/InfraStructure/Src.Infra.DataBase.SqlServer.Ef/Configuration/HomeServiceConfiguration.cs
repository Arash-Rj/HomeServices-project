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
    public class HomeServiceConfiguration : IEntityTypeConfiguration<HomeService>
    {
        public void Configure(EntityTypeBuilder<HomeService> builder)
        {
           builder.HasKey(h => h.Id);

            builder.HasOne(h => h.SubCategory)
                .WithMany(s => s.HomeServices)
                .HasForeignKey(h => h.SubCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(h => h.Title).HasMaxLength(30);

            builder.Property(h => h.Description).HasMaxLength(100);
            builder.HasData(
                new List<HomeService>
                {
                    new HomeService{Id=1, IsActive = true , BasePrice=400 ,
                        Description="ایزوله سازی سطوح سیمانی و جلوگیری از نفوذ اب و رطوبت به دیوار ها و کف." ,
                        SubCategoryId =24 , Title ="آب بندی" , Views=1 , ImagePath= "اب بندی.jpg"},

                    new HomeService{Id=2, IsActive = true , BasePrice=300 ,
                        Description="ترمیم ترک های دیوار و سقف به منظور جلوگیری از اسیب های ناشی از نشست ساختمان یا رطوبت." , SubCategoryId =22 ,
                        Title ="ترمیم ترک" , Views=1 , ImagePath= "ترمیم ترک.jpg"},
                }
                );
         
        }
    }
}
