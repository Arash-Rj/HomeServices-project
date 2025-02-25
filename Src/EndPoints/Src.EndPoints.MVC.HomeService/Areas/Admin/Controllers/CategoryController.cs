using AppFrameWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.HomeServices_Manager.HomeServices.AppService;

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
        public async Task<IActionResult> Create(string title,IFormFile image,CancellationToken cancellationToken)
        {
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
            if(id == 0)
            {
                var subcategories = await _homeServiceAppService.SubCategories(cancellationToken);
                return View("/Areas/Admin/Views/Category/Sub-Category/Index.cshtml",subcategories);
            }
            else
            {
                var selectedSubCategories = await _categoryAppService.GetSubs(id,cancellationToken);
                return View("/Areas/Admin/Views/Category/Sub-Category/Index.cshtml",selectedSubCategories);
            }
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
    }
}
