using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Src.Domain.Core.AAM.ManageAdmin.Entities;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.Domain.Core.Customer_Manager.Customer.Entities;
using Src.Domain.Core.Expert_Manager.Expert.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Src.Infra.DataBase.SqlServer.Ef.Configuration
{
    public class UserConfiguration
    {
        public static void SeedUser(ModelBuilder builder)
        {
            //Seed Admin
            var admins = new List<Admin>()
            {
               new Admin()
                {
                    Id=1,
                    UserName="Arash",
                    NormalizedUserName="ARASH",
                    Email="rajabiarash36@gmail.com",
                    NormalizedEmail="RAJABIARASH36@GMAIL.COM",
                    PhoneNumber="09112789132",
                    LockoutEnabled=true,
                    SecurityStamp=Guid.NewGuid().ToString(),
                    CardNumber="5057222213180000",
                    Province=ProvinceEnum.گلستان,
                    RegisterDate=DateTime.Now,
                    Balance=0,
                    IsActive=true,
                }
             };
            foreach (var admin in admins)
            {
                var passwordHasher = new PasswordHasher<Admin>();
                admin.PasswordHash = passwordHasher.HashPassword(admin,"13831383Ara");
                builder.Entity<Admin>().HasData(admin);
            }

            //Seed Customer
            var customers = new List<AppCustomer>()
            {
               new AppCustomer()
                {
                    Id=2,
                    UserName="Ashkan",
                    NormalizedUserName="ASHKAN",
                    Email="rajabiAshkan36@gmail.com",
                    NormalizedEmail="RAJABIASHKAN36@GMAIL.COM",
                    PhoneNumber="09113889433",
                    LockoutEnabled=true,
                    SecurityStamp=Guid.NewGuid().ToString(),
                    CardNumber="5057222213181111",
                    Province=ProvinceEnum.گلستان,
                    RegisterDate=DateTime.Now,
                    Balance=10000000,
                    Address="Gonbad-Kavoos",
                    IsActive=true,
                }
             };
            foreach (var customer in customers)
            {
                var passwordHasher = new PasswordHasher<AppCustomer>();
                customer.PasswordHash = passwordHasher.HashPassword(customer,"13831383Ashk");
                builder.Entity<AppCustomer>().HasData(customer);
            }

            //Seed Expert
            var experts = new List<AppExpert>()
            {
               new AppExpert()
                {
                    Id=3,
                    UserName="Mahmood",
                    NormalizedUserName ="MAHMOOD",
                    Email="moharerymahmood36@gmail.com",
                    NormalizedEmail="MOHARERYMAHMOOD36@GMAIL.COM",
                    PhoneNumber="09334569433",
                    LockoutEnabled=true,
                    SecurityStamp=Guid.NewGuid().ToString(),
                    CardNumber="5057222213182222",
                    Province=ProvinceEnum.کرج,
                    RegisterDate=DateTime.Now,
                    Balance=10000000,
                    WorkPlaceAddress="عظیمیه-میدان اسبی-پارک",
                    IsActive=true,
                }
             };
            foreach (var expert in experts)
            {
                var passwordHasher = new PasswordHasher<AppExpert>();
                expert.PasswordHash = passwordHasher.HashPassword(expert,"13831383mahmood");
                builder.Entity<AppExpert>().HasData(expert);
            }

            // Seed Roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole<int>() { Id = 3, Name = "Expert", NormalizedName = "EXPERT" }
            );

            //Seed Role To Users
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 3 }
            );
        }

        public static void ConfigureUser(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(x => x.Id);
            builder.Entity<User>().Property(u => u.PhoneNumber).HasMaxLength(11);
            builder.Entity<AppExpert>().Property(e => e.WorkPlaceAddress).HasMaxLength(40);
            builder.Entity<AppCustomer>().Property(c => c.Address).HasMaxLength(60);
            builder.Entity<AppExpert>().ToTable("Experts");
            builder.Entity<AppCustomer>().ToTable("Customers");
            builder.Entity<Admin>().ToTable("Admin");
        }
    }
}
