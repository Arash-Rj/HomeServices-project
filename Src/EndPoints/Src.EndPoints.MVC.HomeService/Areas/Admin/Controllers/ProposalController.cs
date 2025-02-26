using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Src.Domain.Core.Expert_Manager.Expert.AppService;
using Src.Domain.Core.Expert_Manager.Expert.Dtos;

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
        public async Task<IActionResult> Index(CancellationToken cancellationToken,int id=0)
        {
            var proposals = new List<ProposalInfoDto>();
            if(id == 0)
            {
                proposals = await _proposalAppService.GetAllInfo(cancellationToken);
            }
            else
            {
                proposals = await _proposalAppService.GetAllInfo(cancellationToken, id);
            }
            return View(proposals);
        }
    }
}
