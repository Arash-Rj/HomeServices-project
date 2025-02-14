using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.Configuration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
           builder.HasKey(x => x.Id);

           builder.HasOne(i => i.Request)
                .WithMany(r => r.Images)
                .HasForeignKey(i => i.RequestId)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasData(new List<Image>() 
            //{
            //    new Image() {},
            //    new Image() {},
            //    new Image() {},
            //    new Image() {},
            //    new Image() {},
            //    new Image() {},
            //    new Image() {},
            //    new Image() {},
            //    new Image() {},
            //    new Image() {},
            //    new Image() {}
            //}
            //);
        }
    }
}
