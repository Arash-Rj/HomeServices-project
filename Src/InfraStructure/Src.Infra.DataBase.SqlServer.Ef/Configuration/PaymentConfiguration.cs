using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.Payment_Manager.Payment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<AppPayment>
    {
        public void Configure(EntityTypeBuilder<AppPayment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Expert)
                .WithMany(e => e.Payments)
                .HasForeignKey(p => p.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Customer)
                .WithMany(e => e.Payments)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(p => p.Admin)
                .WithMany(e => e.Payments)
                .HasForeignKey(p => p.AdminId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
