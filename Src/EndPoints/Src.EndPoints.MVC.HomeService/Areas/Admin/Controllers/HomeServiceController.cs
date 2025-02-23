using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.HomeServices_Manager.HomeServices.AppService;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeServiceController : Controller
    {
        private readonly IHomeServiceAppService _homeServiceAppService;
        public HomeServiceController(IHomeServiceAppService homeServiceAppService)
        {
            _homeServiceAppService = homeServiceAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var homeserviceDtos = await _homeServiceAppService.GetAllInfo(cancellationToken);
            return View("/Areas/Admin/Views/Category/HomeService/Index.cshtml", homeserviceDtos);
        }
    }
}
