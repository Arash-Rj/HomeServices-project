using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.Expert_Manager.Expert.AppService;

namespace Src.EndPoints.MVC.HomeService.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProposalController : Controller
    {
        private readonly IProposalAppService _proposalAppService;
        public ProposalController(IProposalAppService proposalAppService)
        {
            _proposalAppService = proposalAppService;
        }
        public Task<IActionResult> Index(CancellationToken cancellationToken,int id=0)
        {
            return View();
        }
    }
}
