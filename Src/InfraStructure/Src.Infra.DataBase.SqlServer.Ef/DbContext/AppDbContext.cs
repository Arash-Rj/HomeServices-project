using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Src.Domain.Core.AAM.ManageAdmin.Entities;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Entities;
using Src.Domain.Core.Payment_Manager.Payment.Entities;
using Src.Infra.DataBase.SqlServer.Ef.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.DbContext
{
    public class AppDbContext: IdentityDbContext<User,IdentityRole<int>,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(u => u.Province).HasConversion<string>();
            builder.Entity<User>().HasDiscriminator<string>("UserType")
                .HasValue<AppCustomer>("Customer")
                .HasValue<AppExpert>("Expert")
                .HasValue<Admin>("Admin");
            builder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(11);

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new FeedBackConfiguration());
            builder.ApplyConfiguration(new HomeServiceConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new ProposalConfiguration());
            builder.ApplyConfiguration(new RequestConfiguration());
            builder.ApplyConfiguration(new SubCategoryConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
            UserConfiguration.SeedUser(builder);
        }
        public DbSet<AppRequest> Requests { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<HomeService> HomeServices { get; set; }
        public DbSet<AppPayment> Payments { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<AppExpert> AppExperts { get; set; }
        public DbSet<AppCustomer> AppCustomers { get; set; }
    }
}
