using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.Expert_Manager.Expert.AppService;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;
using Src.Domain.Core.Expert_Manager.Expert.Enums;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeedBackController : Controller
    {
        private readonly IFeedBackAppService _feedBackAppService;
        public FeedBackController(IFeedBackAppService feedBackAppService)
        {
            _feedBackAppService = feedBackAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken,int expertId=0)
        {
            var feedbackDtos = new List<FeedBackDto>();
            if (expertId == 0)
            {
                 feedbackDtos = await _feedBackAppService.GetAllInfo(cancellationToken);
            }
            else
            {
                 feedbackDtos = await _feedBackAppService.GetAllInfo(cancellationToken,expertId);
            }
            return View(feedbackDtos);
        }
        public async Task<IActionResult> ChangeStatus(int id, FeedBackStatus feedBackStatus, CancellationToken cancellationToken)
        {
            var result = await _feedBackAppService.ChangeStatus(id, feedBackStatus, cancellationToken);
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
