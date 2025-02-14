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
    public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
           builder.HasKey(x => x.Id);

            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(p => p.Expert)
                .WithMany(e => e.Proposals)
                .HasForeignKey(p => p.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);

           
        }
    }
}
