using AppFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.HomeServices_Manager.HomeServices.AppService;
using Src.Domain.Core.HomeServices_Manager.HomeServices.Dtos;
using Src.EndPoints.MVC.HomeService.Areas.Admin.Models;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IHomeServiceAppService _homeServiceAppService;
        public CategoryController(ICategoryAppService categoryAppService,IHomeServiceAppService homeServiceAppService)
        {
            _categoryAppService = categoryAppService;
            _homeServiceAppService = homeServiceAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken )
        {
            var categories = await _categoryAppService.GetAllInfo(cancellationToken);
            return View("/Areas/Admin/Views/Category/Index.cshtml", categories);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string title,IFormFile image,CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
            {
                return View("/Areas/Admin/Views/Category/Index.cshtml");
            }
            string imagePath="";
            try
            {
                 imagePath = await StaticMethods.UploadImage(image, "Categories", cancellationToken);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            var result = await _categoryAppService.Add(cancellationToken,title, imagePath);
            if(result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Subcategories(CancellationToken cancellationToken, int id = 0)
        {
            var subcategories = new List<SubcategoryDto>();
            var categories = await _categoryAppService.GetAllInfo(cancellationToken);
            if(id == 0)
            {
                 subcategories = await _homeServiceAppService.SubCategories(cancellationToken);
            }
            else
            {
                subcategories = await _categoryAppService.GetSubs(id,cancellationToken);
            }
            var displayServiecModel = new DisplayServiceModels();
            foreach(var cat in categories)
            {
                var displayCategoryModel = new DisplayCategoryModel()
                {
                    Id = cat.Id,
                    Title = cat.Title,
                };
                displayServiecModel.Categories.Add(displayCategoryModel);
            }
            displayServiecModel.Subcategories = subcategories;
            return View("/Areas/Admin/Views/Category/Sub-Category/Index.cshtml", displayServiecModel);
        }

        public async Task<IActionResult> Delete(int id,CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.Delete(id,cancellationToken);
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
        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(DisplayServiceModels homeServiecModel,CancellationToken cancellationToken)
        {
            string imagePath = "";
            try
            {
                imagePath = await StaticMethods.UploadImage(homeServiecModel.CreateSubCategoryModel.ImageFile, "Sub-Categories", cancellationToken);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            #region Mapping
            var subCategoryDto = new SubcategoryDto()
            {
                ImagePath = imagePath,
                CategoryId = homeServiecModel.CreateSubCategoryModel.CategoryId,
                Name = homeServiecModel.CreateSubCategoryModel.Title,
            };
            #endregion

            var result = await _homeServiceAppService.CreateSubCategory(subCategoryDto, cancellationToken);
            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }
            return RedirectToAction("Subcategories");
        }
    }
}
