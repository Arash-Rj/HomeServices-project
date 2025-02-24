using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.Customer_Manager.Customer.AppService;
using Src.Domain.Core.Customer_Manager.Customer.Enums;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RequestController : Controller
    {
        private readonly IRequestAppService _requestAppService;
        public RequestController(IRequestAppService requestAppService)
        {           
            _requestAppService = requestAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var requests = await _requestAppService.GetAllInfo(cancellationToken);
            return View(requests);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, ReqStatus reqStatus, CancellationToken cancellationToken)
        {
            var result = await _requestAppService.ChangeStatus(id, reqStatus, cancellationToken);
            if (result.Success)
            {
                TempData["SuccessMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
