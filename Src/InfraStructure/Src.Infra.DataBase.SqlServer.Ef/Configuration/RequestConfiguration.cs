using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Enums;
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

            builder.HasData(
                new AppRequest()
                {
                    Id = 1,
                    IsActive = true,
                    CustomerId = 2,
                    HomeServiceId = 2,
                    ExecutionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                    ExecutionTime = new TimeOnly(16,40),
                    Details="نیاز به ترمیم ترک سقف خانه دارم.",
                    RequestDate = DateTime.Now,
                    Status = ReqStatus.Success,
                }
                );
        }
    }
}
