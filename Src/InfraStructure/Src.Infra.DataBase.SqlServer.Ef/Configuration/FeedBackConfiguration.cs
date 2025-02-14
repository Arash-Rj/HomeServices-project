using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.Configuration
{
    public class FeedBackConfiguration : IEntityTypeConfiguration<FeedBack>
    {
        public void Configure(EntityTypeBuilder<FeedBack> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(f => f.Description).HasMaxLength(70).IsRequired();

            builder.HasOne(f => f.Expert)
                .WithMany(e => e.FeedBacks)
                .HasForeignKey(f => f.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.Customer)
                 .WithMany(c => c.FeedBacks)
                 .HasForeignKey(f => f.CustomerId)
                 .OnDelete(DeleteBehavior.NoAction);
        } 
    }
}
