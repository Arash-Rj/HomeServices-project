using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.AAM.ManageUser.AppService;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.EndPoints.MVC.HomeService.Models;
using System.Runtime.CompilerServices;

namespace Src.EndPoints.MVC.HomeService.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            var loginmodel = new UserLoginModel();
            return View(loginmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel,CancellationToken cancellationToken) //Remember to Add Remember me
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginModel);
            }
            var result =await _userAppService.Login(userLoginModel.UserName,userLoginModel.Password,true,cancellationToken);
            if(!result.Success)
            {
                ViewBag.ErrorMessage =result.Message;
                return View();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            var registermodel = new UserRegisterModel();
            return View(registermodel);
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel userRegisterModel,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterModel);
            }
            var userdto = new UserDto()
            {
                UserName = userRegisterModel.UserName,
                Email = userRegisterModel.Email,
                Password = userRegisterModel.Password,
                Role = userRegisterModel.Role
            };
            var result = await _userAppService.Register(userdto, cancellationToken);
            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View();
            }
            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction("Index");
        }
    }
}
