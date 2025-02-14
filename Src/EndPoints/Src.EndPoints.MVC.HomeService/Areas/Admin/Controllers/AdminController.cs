using Microsoft.AspNetCore.Mvc;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
