using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.AAM.ManageUser.AppService;
using Src.Domain.Core.Customer_Manager.Customer.AppService;
using Src.EndPoints.MVC.HomeService.Areas.Admin.Models;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ICustomerAppService _customerAppService;
        public CustomerController(IUserAppService userAppService, ICustomerAppService customerAppService)
        {
            _userAppService = userAppService;
            _customerAppService = customerAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var customerDtos = await _customerAppService.GetAllInfo(cancellationToken);
            return View(customerDtos);
        }
    }
}
