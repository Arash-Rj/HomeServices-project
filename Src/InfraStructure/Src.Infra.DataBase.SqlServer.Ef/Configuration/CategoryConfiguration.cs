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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(c => c.SubCategories)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

           builder.Property(c => c.Title).HasMaxLength(40);

            builder.Property(c => c.Title).HasConversion<string>();

            builder.HasData(new List<Category>()
            { 
                new Category { Id=1 , Title=CategoryEnum.ElectricalServices , ImagePath="Images/Categories/برق-کشی-1.jpg" },
                 new Category { Id=2 , Title=CategoryEnum.PaintingServices , ImagePath="Images/Categories/نقاشی.jpg" },
                  new Category { Id=3 , Title=CategoryEnum.ApplianceRepairServices , ImagePath = "Images/Categories/تعمیر-لوازم-خانگی.jpg"},
                   new Category { Id=4 , Title=CategoryEnum.CleaningServices , ImagePath = "Images/Categories/بهداشت-و-نظافت.jpg"},
                    new Category { Id=5 , Title=CategoryEnum.PestControlServices , ImagePath = "Images/Categories/سمپاشی.jpg"},
                     new Category { Id=6 , Title=CategoryEnum.HomeRenovation , ImagePath = "Images/Categories/دکوراسیون-داخلی.jpg"},
                      new Category { Id=7 , Title=CategoryEnum.HVAC, ImagePath = "Images/Categories/تاسیسات-ساختمان.jpg"},
                       new Category { Id=8, Title=CategoryEnum.PlumbingServices , ImagePath = "Images/Categories/لوله-کشی.jpg"},
                        new Category { Id=9, Title=CategoryEnum.HomeSecurityServices , ImagePath = "Images/Categories/ایمنی-و-امنیت-ساختمان.jpg"},
                         new Category { Id=10, Title=CategoryEnum.CarpentryAndWoodwork , ImagePath = "Images/Categories/نجاری.jpg"},
                          new Category { Id=11, Title=CategoryEnum.Masonry , ImagePath = "Images/Categories/بنایی.jpg"}
            }
            );
        }
    }
}
