using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Src.Domain.AppService.AAM.ManageAdmin.Entities;
using Src.Domain.AppService.AAM.ManageUser.Entities;
using Src.Domain.AppService.Customer_Manager.Customer;
using Src.Domain.AppService.Customer_Manager.Request;
using Src.Domain.AppService.Expert_Manager.Proposal;
using Src.Domain.AppService.Payment_Manager.Payment;
using Src.Domain.AppService.Services_Manager.Service;
using Src.Domain.Core.AAM.ManageAdmin.AppService;
using Src.Domain.Core.AAM.ManageAdmin.Repository;
using Src.Domain.Core.AAM.ManageAdmin.Service;
using Src.Domain.Core.AAM.ManageUser.AppService;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.Repository;
using Src.Domain.Core.AAM.ManageUser.Service;
using Src.Domain.Core.Customer_Manager.Customer.AppService;
using Src.Domain.Core.Customer_Manager.Customer.Repository;
using Src.Domain.Core.Customer_Manager.Customer.Service;
using Src.Domain.Core.Expert_Manager.Expert.AppService;
using Src.Domain.Core.Expert_Manager.Expert.Repository;
using Src.Domain.Core.Expert_Manager.Expert.Service;
using Src.Domain.Core.HomeServices_Manager.HomeServices.AppService;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Repository;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Service;
using Src.Domain.Core.Payment_Manager.Payment.AppService;
using Src.Domain.Core.Payment_Manager.Payment.Repository;
using Src.Domain.Core.Payment_Manager.Payment.Service;
using Src.Domain.Service.AAM.ManageAdmin;
using Src.Domain.Service.AAM.ManageUser;
using Src.Domain.Service.Customer_Manager.Customer;
using Src.Domain.Service.Customer_Manager.Request;
using Src.Domain.Service.Expert_Manager.Proposal;
using Src.Domain.Service.HomeServices_Manager.HomeService;
using Src.Domain.Service.Payment_Manager.Payment;
using Src.Ifra.DataAccess.Repos.Ef.AAM.ManageAdmin;
using Src.Ifra.DataAccess.Repos.Ef.AAM.ManageUser;
using Src.Ifra.DataAccess.Repos.Ef.Customer_Manager.Customer;
using Src.Ifra.DataAccess.Repos.Ef.Customer_Manager.Request;
using Src.Ifra.DataAccess.Repos.Ef.Expert_Manager.Proposal;
using Src.Ifra.DataAccess.Repos.Ef.HomeServices_Manager.HomeServices;
using Src.Ifra.DataAccess.Repos.Ef.Payment_Manager.Payment;
using Src.Infra.DataBase.SqlServer.Ef.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
string? connectionstring = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
}
)
.AddRoles<IdentityRole<int>>()
.AddEntityFrameworkStores<AppDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Admin/Home/Login";
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminAppService, AdminAppService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();

builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();

builder.Services.AddScoped<IProposalRepository, ProposalRepository>();
builder.Services.AddScoped<IProposalService, ProposalService>();
builder.Services.AddScoped<IProposalAppService, ProposalAppService>();

builder.Services.AddScoped<IHomeServiceRepository, HomeServicesRepository>();
builder.Services.AddScoped<IHomeServiceService, HomeServicesService>();
builder.Services.AddScoped<IHomeServiceAppService, HomeServiceAppService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentAppService, PaymentAppService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
