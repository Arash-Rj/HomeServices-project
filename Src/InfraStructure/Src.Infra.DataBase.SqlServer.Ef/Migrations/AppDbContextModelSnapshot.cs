﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;

#nullable disable

namespace Src.Infra.DataBase.SqlServer.Ef.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Expert",
                            NormalizedName = "EXPERT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Src.Domain.Core.AAM.ManageUser.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Src.Domain.Core.Base.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Src.Domain.Core.Customer_Manager.Customer.Entities.AppRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("ExecutionDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("ExecutionTime")
                        .HasColumnType("time");

                    b.Property<string>("HomeServiceTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("RequestDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Src.Domain.Core.Expert_Manager.Expert.Entities.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpertId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("Src.Domain.Core.Expert_Manager.Expert.Entities.Proposal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateOnly>("ProposalDate")
                        .HasColumnType("date");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("RequestId");

                    b.ToTable("Proposals");
                });

            modelBuilder.Entity("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImagePath = "Images/Categories/برق-کشی-1.jpg",
                            Title = "ElectricalServices"
                        },
                        new
                        {
                            Id = 2,
                            ImagePath = "Images/Categories/نقاشی.jpg",
                            Title = "PaintingServices"
                        },
                        new
                        {
                            Id = 3,
                            ImagePath = "Images/Categories/تعمیر-لوازم-خانگی.jpg",
                            Title = "ApplianceRepairServices"
                        },
                        new
                        {
                            Id = 4,
                            ImagePath = "Images/Categories/بهداشت-و-نظافت.jpg",
                            Title = "CleaningServices"
                        },
                        new
                        {
                            Id = 5,
                            ImagePath = "Images/Categories/سمپاشی.jpg",
                            Title = "PestControlServices"
                        },
                        new
                        {
                            Id = 6,
                            ImagePath = "Images/Categories/دکوراسیون-داخلی.jpg",
                            Title = "HomeRenovation"
                        },
                        new
                        {
                            Id = 7,
                            ImagePath = "Images/Categories/تاسیسات-ساختمان.jpg",
                            Title = "HVAC"
                        },
                        new
                        {
                            Id = 8,
                            ImagePath = "Images/Categories/لوله-کشی.jpg",
                            Title = "PlumbingServices"
                        },
                        new
                        {
                            Id = 9,
                            ImagePath = "Images/Categories/ایمنی-و-امنیت-ساختمان.jpg",
                            Title = "HomeSecurityServices"
                        },
                        new
                        {
                            Id = 10,
                            ImagePath = "Images/Categories/نجاری.jpg",
                            Title = "CarpentryAndWoodwork"
                        },
                        new
                        {
                            Id = 11,
                            ImagePath = "Images/Categories/بنایی.jpg",
                            Title = "Masonry"
                        });
                });

            modelBuilder.Entity("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.HomeService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("BasePrice")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("HomeServices");
                });

            modelBuilder.Entity("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AppExpertId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppExpertId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Src.Domain.Core.Payment_Manager.Payment.Entities.AppPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ExpertId")
                        .HasColumnType("int");

                    b.Property<string>("ExpertName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ExpertId");

                    b.HasIndex("RequestId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Src.Domain.Core.AAM.ManageAdmin.Entities.Admin", b =>
                {
                    b.HasBaseType("Src.Domain.Core.AAM.ManageUser.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            Address = "Defult",
                            Balance = 0f,
                            CardNumber = "5057222213180000",
                            ConcurrencyStamp = "bf85097a-36ea-45f0-9c9d-06306ce405fc",
                            Email = "rajabiarash36@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "RAJABIARASH36@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEBqtJ1K/jI5YqiOSIYh9Jm93IgE9xZU6yrywWRFdVA6tXoRoNxnCsZAQib9+x8Tuxg==",
                            PhoneNumber = "09112789132",
                            PhoneNumberConfirmed = false,
                            Province = "گلستان",
                            RegisterDate = new DateTime(2025, 2, 13, 22, 19, 43, 778, DateTimeKind.Local).AddTicks(5890),
                            SecurityStamp = "2ac8e515-14de-42a4-b1b3-411f27d423d3",
                            TwoFactorEnabled = false,
                            UserName = "Arash"
                        });
                });

            modelBuilder.Entity("Src.Domain.Core.Customer_Manager.Customer.Entities.AppCustomer", b =>
                {
                    b.HasBaseType("Src.Domain.Core.AAM.ManageUser.Entities.User");

                    b.HasDiscriminator().HasValue("Customer");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            Address = "Gonbad-Kavoos",
                            Balance = 10000000f,
                            CardNumber = "5057222213181111",
                            ConcurrencyStamp = "d40b23e3-9fb7-4889-832f-f56210dfbbe7",
                            Email = "rajabiAshkan36@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "RAJABIASHKAN36@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEKjkpQbZsMYooeWNFSc3WqWedZhaXfM58+SPLSdugEEC/Pl/RMmi1jfOBry4Xn1Mlg==",
                            PhoneNumber = "09113889433",
                            PhoneNumberConfirmed = false,
                            Province = "گلستان",
                            RegisterDate = new DateTime(2025, 2, 13, 22, 19, 43, 817, DateTimeKind.Local).AddTicks(5298),
                            SecurityStamp = "d8b26783-396f-4a2f-954b-610f9563dbd9",
                            TwoFactorEnabled = false,
                            UserName = "Ashkan"
                        });
                });

            modelBuilder.Entity("Src.Domain.Core.Expert_Manager.Expert.Entities.AppExpert", b =>
                {
                    b.HasBaseType("Src.Domain.Core.AAM.ManageUser.Entities.User");

                    b.HasDiscriminator().HasValue("Expert");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            Address = "Karaj",
                            Balance = 10000000f,
                            CardNumber = "5057222213182222",
                            ConcurrencyStamp = "c7f82df4-5249-4ced-9802-820c2945cae3",
                            Email = "moharerymahmood36@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = true,
                            NormalizedEmail = "MOHARERYMAHMOOD36@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMwiNEyLAEcomKGVuArZZV/Q7MAjFaDVwP4Nd6bIJb3iyzwTgw+ZdVfSBTWl464dgw==",
                            PhoneNumber = "09334569433",
                            PhoneNumberConfirmed = false,
                            Province = "کرج",
                            RegisterDate = new DateTime(2025, 2, 13, 22, 19, 43, 854, DateTimeKind.Local).AddTicks(9468),
                            SecurityStamp = "de5b6283-4276-4fe2-b923-41b3152a5d65",
                            TwoFactorEnabled = false,
                            UserName = "Mahmood"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Src.Domain.Core.AAM.ManageUser.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Src.Domain.Core.AAM.ManageUser.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Src.Domain.Core.AAM.ManageUser.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Src.Domain.Core.AAM.ManageUser.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Src.Domain.Core.Base.Entities.Image", b =>
                {
                    b.HasOne("Src.Domain.Core.Customer_Manager.Customer.Entities.AppRequest", "Request")
                        .WithMany("Images")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Src.Domain.Core.Customer_Manager.Customer.Entities.AppRequest", b =>
                {
                    b.HasOne("Src.Domain.Core.Customer_Manager.Customer.Entities.AppCustomer", "Customer")
                        .WithMany("Requests")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Src.Domain.Core.Expert_Manager.Expert.Entities.FeedBack", b =>
                {
                    b.HasOne("Src.Domain.Core.Customer_Manager.Customer.Entities.AppCustomer", "Customer")
                        .WithMany("FeedBacks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Src.Domain.Core.Expert_Manager.Expert.Entities.AppExpert", "Expert")
                        .WithMany("FeedBacks")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Expert");
                });

            modelBuilder.Entity("Src.Domain.Core.Expert_Manager.Expert.Entities.Proposal", b =>
                {
                    b.HasOne("Src.Domain.Core.Expert_Manager.Expert.Entities.AppExpert", "Expert")
                        .WithMany("Proposals")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Src.Domain.Core.Customer_Manager.Customer.Entities.AppRequest", "Request")
                        .WithMany("Proposals")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.HomeService", b =>
                {
                    b.HasOne("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.SubCategory", "SubCategory")
                        .WithMany("HomeServices")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.SubCategory", b =>
                {
                    b.HasOne("Src.Domain.Core.Expert_Manager.Expert.Entities.AppExpert", null)
                        .WithMany("Specialties")
                        .HasForeignKey("AppExpertId");

                    b.HasOne("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Src.Domain.Core.Payment_Manager.Payment.Entities.AppPayment", b =>
                {
                    b.HasOne("Src.Domain.Core.AAM.ManageAdmin.Entities.Admin", "Admin")
                        .WithMany("Payments")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Src.Domain.Core.Customer_Manager.Customer.Entities.AppCustomer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Src.Domain.Core.Expert_Manager.Expert.Entities.AppExpert", "Expert")
                        .WithMany("Payments")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Src.Domain.Core.Customer_Manager.Customer.Entities.AppRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Customer");

                    b.Navigation("Expert");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Src.Domain.Core.Customer_Manager.Customer.Entities.AppRequest", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Proposals");
                });

            modelBuilder.Entity("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Src.Domain.Core.HomeServices_Manager.HomeServices.Entities.SubCategory", b =>
                {
                    b.Navigation("HomeServices");
                });

            modelBuilder.Entity("Src.Domain.Core.AAM.ManageAdmin.Entities.Admin", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Src.Domain.Core.Customer_Manager.Customer.Entities.AppCustomer", b =>
                {
                    b.Navigation("FeedBacks");

                    b.Navigation("Payments");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Src.Domain.Core.Expert_Manager.Expert.Entities.AppExpert", b =>
                {
                    b.Navigation("FeedBacks");

                    b.Navigation("Payments");

                    b.Navigation("Proposals");

                    b.Navigation("Specialties");
                });
#pragma warning restore 612, 618
        }
    }
}
