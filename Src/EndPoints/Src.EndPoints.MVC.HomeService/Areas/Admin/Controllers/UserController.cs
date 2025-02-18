using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.AAM.ManageUser.AppService;
using Src.Domain.Core.Customer_Manager.Customer.AppService;
using Src.Domain.Core.Expert_Manager.Expert.AppService;
using Src.EndPoints.MVC.HomeService.Areas.Admin.Models;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IExpertAppService _expertAppService;
        public UserController(IUserAppService userAppService, ICustomerAppService customerAppService,IExpertAppService expertAppService)
        {
            _userAppService = userAppService;
            _customerAppService = customerAppService;
            _expertAppService = expertAppService;
        }
        //[HttpGet("Get-All-Users")]
        public async Task<IActionResult> AllUsers(CancellationToken cancellationToken)
        {
            var customerDtos = await _customerAppService.GetAllInfo(cancellationToken);
            return View(customerDtos);
        }
        //[HttpGet("Get-All-Customers")]
        public async Task<IActionResult> AllCustomers(CancellationToken cancellationToken)
        {
            var customerDtos = await _customerAppService.GetAllInfo(cancellationToken);
            return View("/Areas/Admin/Views/User/Customer/AllCustomers.cshtml", customerDtos);
        }
        //[HttpGet("Get-All-Experts")]
        public async Task<IActionResult> AllExperts(CancellationToken cancellationToken)
        {
            var expertDtos = await _expertAppService.GetAllInfo(cancellationToken);
            return View("/Areas/Admin/Views/User/Expert/AllExperts.cshtml", expertDtos);
        }
    }
}
