using AppFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.AppService.Services_Manager.Category;
using Src.Domain.Core.HomeServices_Manager.HomeServices;
using Src.Domain.Core.HomeServices_Manager.HomeServices.AppService;
using Src.EndPoints.MVC.HomeService.Areas.Admin.Models;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeServiceController : Controller
    {
        HomeServiceDto HomeServiceDto { get; set; }
        private readonly IHomeServiceAppService _homeServiceAppService;
        public HomeServiceController(IHomeServiceAppService homeServiceAppService)
        {
            _homeServiceAppService = homeServiceAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var homeserviceDtos = await _homeServiceAppService.GetAllInfo(cancellationToken);
            var SubCategories = await _homeServiceAppService.SubCategories(cancellationToken);
            var homeServiceModel = new HomeServiceModel();
            homeServiceModel.HomeServices = homeserviceDtos;
            homeServiceModel.Subcategories = SubCategories;
            return View("/Areas/Admin/Views/Category/HomeService/Index.cshtml",homeServiceModel);
        }
        public async Task<IActionResult> Create(HomeServiceModel model,CancellationToken cancellationToken)
        {
            string imagePath = "";
            var createHomeService = new HomeServiceDto();
            try
            {
                imagePath = await StaticMethods.UploadImage(model.CreateHomeServiceModel.ImageFile,"HomeServices", cancellationToken);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            #region Mapping
            createHomeService.Title = model.CreateHomeServiceModel.Title;
            createHomeService.BasePrice = model.CreateHomeServiceModel.BasePrice;
            createHomeService.ImagePath = imagePath;
            createHomeService.SubcategoryId = model.CreateHomeServiceModel.SubcategoryId;
            createHomeService.Description = model.CreateHomeServiceModel.Description;
            #endregion
            var result = await _homeServiceAppService.Add(createHomeService,cancellationToken);
            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
