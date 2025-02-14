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

            builder.Property(h => h.Status).HasConversion<string>();
        }
    }
}
