using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.AAM.ManageUser.AppService;
using Src.Domain.Core.AAM.ManageUser.Entities;
using Src.Domain.Core.AAM.ManageUser.Enums;
using Src.Domain.Core.Base.Entities;
using Src.Domain.Core.Customer_Manager.Customer.AppService;
using Src.Domain.Core.Customer_Manager.Customer.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.AppService;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.EndPoints.MVC.HomeService.Areas.Admin.Models;
using Src.EndPoints.MVC.HomeService.Models;
using System.Data;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IExpertAppService _expertAppService;
        private readonly UserManager<User> _userManager;
        public UserController(IUserAppService userAppService, ICustomerAppService customerAppService,
            IExpertAppService expertAppService, UserManager<User> userManager)
        {
            _userAppService = userAppService;
            _customerAppService = customerAppService;
            _expertAppService = expertAppService;
            _userManager = userManager;
        }

        public async Task<IActionResult> AllUsers(CancellationToken cancellationToken)
        {
            var customerDtos = await _customerAppService.GetAllInfo(cancellationToken);
            return View(customerDtos);
        }

        public async Task<IActionResult> AllCustomers(CancellationToken cancellationToken)
        {
            var customerDtos = await _customerAppService.GetAllInfo(cancellationToken);
            return View("/Areas/Admin/Views/User/Customer/AllCustomers.cshtml", customerDtos);
        }

        public async Task<IActionResult> AllExperts(CancellationToken cancellationToken)
        {
            var expertDtos = await _expertAppService.GetAllInfo(cancellationToken);
            return View("/Areas/Admin/Views/User/Expert/AllExperts.cshtml", expertDtos);
        }

        public IActionResult Create()
        {
            return View("/Areas/Admin/Views/User/Create.cshtml");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(UserRegisterModel userRegisterModel,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterModel);
            }
            #region Mapping
            var user = new UserDto()
            {
                UserName = userRegisterModel.UserName,
                Email = userRegisterModel.Email,
                Password = userRegisterModel.Password,
                Role = userRegisterModel.Role,    
            };
            #endregion

          var result = await _userAppService.Register(user,cancellationToken);
            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View("/Areas/Admin/Views/User/Create.cshtml");
            }
            TempData["SuccessMessage"] = result.Message;
            return RedirectToAction("Index","Home");
        }
        
     
        public async Task<IActionResult> Update(int id,CancellationToken cancellationToken)
        {
            var role = await _userAppService.GetRole(id,cancellationToken);
            if(role == RoleEnum.Customer)
            {
                var updateCustomerDto = await _customerAppService.GetDetailedInfo(id,cancellationToken);
                #region Mapping 
                var updateModel = new UpdateUserModel
                {
                    Address = updateCustomerDto.Address,
                    IsActive = updateCustomerDto.IsActive,
                    CardNumber = updateCustomerDto.CardNumber,
                    Email = updateCustomerDto.Email,
                    Id = updateCustomerDto.Id,
                    Name = updateCustomerDto.Name,
                    Phone= updateCustomerDto.Phone,
                    Province = updateCustomerDto.Province,
                    Role = RoleEnum.Customer,
                    ImagePath = updateCustomerDto.ImagePath
                };
                #endregion
                return View("/Areas/Admin/Views/User/Update.cshtml", updateModel);
            }
            if (role == RoleEnum.Expert)
            {
                var updateExpertDto = await _expertAppService.GetDetailedInfo(id,cancellationToken);
                #region Mapping
                var updateModel = new UpdateUserModel
                {
                    IsActive = updateExpertDto.IsActive,
                    CardNumber = updateExpertDto.CardNumber,
                    Email = updateExpertDto.Email,
                    Id = updateExpertDto.Id,
                    Name = updateExpertDto.Name,
                    Phone = updateExpertDto.Phone,
                    Province = updateExpertDto.Province,
                    Role = RoleEnum.Expert,
                    Bioghraphy = updateExpertDto.Bioghraphy,
                    WorkPlaceAddress = updateExpertDto.WorkPlaceAddress,
                    ImagePath = updateExpertDto.ImagePath
                };
                #endregion
                return View("/Areas/Admin/Views/User/Update.cshtml", updateModel);
            }
            else
            {
                TempData["ErrorMessage"] = "مشکلی پیش امد. لطفا دوباره تلاش کنید.";
                return RedirectToAction("AllUsers");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserModel updateUserModel, CancellationToken cancellationToken)
        {
            if (updateUserModel.Role == RoleEnum.Customer)
            {

                #region Mapping 
                var updateCustomerDto = new UpdateCustomerDto
                {
                    Address = updateUserModel.Address,
                    IsActive = updateUserModel.IsActive,
                    CardNumber = updateUserModel.CardNumber,
                    Email = updateUserModel.Email,
                    Id = updateUserModel.Id,
                    Name = updateUserModel.Name,
                    Phone = updateUserModel.Phone,
                    Province = updateUserModel.Province,
                    ImagePath = updateUserModel.ImagePath
                };
                #endregion
                var result = await _customerAppService.Update(updateCustomerDto, cancellationToken);
                if(!result.Success)
                {
                    ViewBag.ErrorMessage = result.Message;
                    return View("/Areas/Admin/Views/User/Update.cshtml");
                }
                else
                {
                    TempData["SuccessMessage"] = $"مشتری {updateUserModel.Name} با موفقیت تغییر یافت.";
                    return RedirectToAction("AllCustomers");
                }
            }
            if (updateUserModel.Role == RoleEnum.Expert)
            {
                #region Mapping
                var updateExpertDto = new UpdateExpertDto
                {
                    IsActive = updateUserModel.IsActive,
                    CardNumber = updateUserModel.CardNumber,
                    Email = updateUserModel.Email,
                    Id = updateUserModel.Id,
                    Name = updateUserModel.Name,
                    Phone = updateUserModel.Phone,
                    Province = updateUserModel.Province,
                    Bioghraphy = updateUserModel.Bioghraphy,
                    WorkPlaceAddress = updateUserModel.WorkPlaceAddress,
                    ImagePath = updateUserModel.ImagePath
                };
                #endregion
                var result = await _expertAppService.Update(updateExpertDto, cancellationToken);
                if (!result.Success)
                {
                    ViewBag.ErrorMessage = result.Message;
                    return View("/Areas/Admin/Views/User/Update.cshtml");
                }
                else
                {
                    TempData["SuccessMessage"] = $"کارشناس {updateUserModel.Name} با موفقیت تغییر یافت.";
                    return RedirectToAction("AllExperts");
                }
            }
            ViewBag.ErrorMessage = "مشکلی پیش امد! لطفا دوباره تلاش کنید.";
            return View("/Areas/Admin/Views/User/Update.cshtml");
        }

        public async Task<IActionResult> UserDetails(int id,RoleEnum role,CancellationToken cancellationToken)
        {
            if (role == RoleEnum.Customer)
            {
                var customerDetails = await _customerAppService.GetDetailedInfo(id,cancellationToken);
                #region Mapping 
                var updateModel = new UpdateUserModel
                {
                    Address = customerDetails.Address,
                    IsActive = customerDetails.IsActive,
                    CardNumber = customerDetails.CardNumber,
                    Email = customerDetails.Email,
                    Id = customerDetails.Id,
                    Name = customerDetails.Name,
                    Phone = customerDetails.Phone,
                    Province = customerDetails.Province,
                    Role = RoleEnum.Customer,
                    ImagePath = customerDetails.ImagePath
                };
                #endregion
                return View("/Areas/Admin/Views/User/UserDetails.cshtml", updateModel);
            }
            if (role == RoleEnum.Expert)
            {
                var expertDetails = await _expertAppService.GetDetailedInfo(id,cancellationToken);
                #region Mapping
                var updateModel = new UpdateUserModel
                {
                    CardNumber = expertDetails.CardNumber,
                    IsActive = expertDetails.IsActive,
                    Email = expertDetails.Email,
                    Id = expertDetails.Id,
                    Name = expertDetails.Name,
                    Phone = expertDetails.Phone,
                    Province = expertDetails.Province,
                    Role = RoleEnum.Expert,
                    Bioghraphy = expertDetails.Bioghraphy,
                    WorkPlaceAddress = expertDetails.WorkPlaceAddress,
                    ImagePath = expertDetails.ImagePath
                };
                #endregion
                return View("/Areas/Admin/Views/User/UserDetails.cshtml", updateModel);
            }
            return RedirectToAction("AllUsers");
        }
    }
}
