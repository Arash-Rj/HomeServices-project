using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.AAM.ManageUser.AppService;
using Src.EndPoints.MVC.HomeService.Areas.Admin.Models;
using Src.EndPoints.MVC.HomeService.Models;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IUserAppService _userAppService;
        public AdminController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            var loginmodel = new AdminLoginModel();
            return View(loginmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginModel adminLoginModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(adminLoginModel);
            }
            var result = await _userAppService.Login(adminLoginModel.UserName, adminLoginModel.Password, adminLoginModel.RememberMe, cancellationToken);
            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
