using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.Configuration
{
    public class RequestConfiguration : IEntityTypeConfiguration<AppRequest>
    {
        public void Configure(EntityTypeBuilder<AppRequest> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(r=>r.Proposals)
                .WithOne(p => p.Request)
                .HasForeignKey(p => p.RequestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(r => r.Images)
                .WithOne(i => i.Request)
                .HasForeignKey(i => i.RequestId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(r => r.Status).HasConversion<string>();
        }
    }
}
