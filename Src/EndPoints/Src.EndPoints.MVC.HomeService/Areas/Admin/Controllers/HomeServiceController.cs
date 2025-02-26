using AppFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public async Task<IActionResult> Index(CancellationToken cancellationToken,int id=0)
        {
            var homeserviceDtos = new List<HomeServiceDto>();
            if (id==0)
            {
                 homeserviceDtos = await _homeServiceAppService.GetAllInfo(cancellationToken);
            }
            else
            {
                homeserviceDtos = await _homeServiceAppService.GetAllInfo(cancellationToken,id);
            }
            var SubCategories = await _homeServiceAppService.SubCategories(cancellationToken);
            var displayServiecModel = new DisplayServiceModels();
            foreach(var hom in homeserviceDtos)
            {
                var createHomeModel = new CreateHomeServiceModel()
                {
                    Id = hom.Id,
                    ImagePath = hom.ImagePath,
                    IsActive = hom.IsActive,
                    SubcategoryName = hom.SubCategoryName,
                    Description = hom.Description,
                    BasePrice = hom.BasePrice,
                    Title = hom.Title
                };
                displayServiecModel.HomeServiceModels.Add(createHomeModel);
            }
            displayServiecModel.Subcategories = SubCategories;
            return View("/Areas/Admin/Views/Category/HomeService/Index.cshtml", displayServiecModel);
        }
        public async Task<IActionResult> Create(DisplayServiceModels model,CancellationToken cancellationToken)
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
        public async Task<IActionResult> Update(CreateHomeServiceModel serviceModels , CancellationToken cancellationToken)
        {
            var createHomeService = new HomeServiceDto();
            string imagePath = "";
            if(ModelState.IsValid)
            {

            }
            if (serviceModels.ImageFile is not null)
            {
                try
                {
                    imagePath = await StaticMethods.UploadImage(serviceModels.ImageFile, "HomeServices", cancellationToken);
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
            }
            else
            {

               var oldpath = serviceModels.ImagePath.Split('/');
                imagePath = oldpath.Last();
            }
            #region Mapping
            createHomeService.Title = serviceModels.Title;
            createHomeService.BasePrice = serviceModels.BasePrice;
            createHomeService.IsActive = serviceModels.IsActive;
            createHomeService.ImagePath = imagePath;
            createHomeService.SubcategoryId = serviceModels.SubcategoryId;
            createHomeService.Description = serviceModels.Description;
            createHomeService.Id = serviceModels.Id;
            #endregion
            var result = await _homeServiceAppService.Update(createHomeService, cancellationToken);
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
