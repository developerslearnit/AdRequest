using AdmonRequest.Application.Constants;
using AdmonRequest.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace AdmonRequest.WebUI.Controllers
{
    [Authorize]
    
    public class HomeController : BaseController
    {

        private readonly IAppService _appService;
        public HomeController(IAppService appService)
        {
            _appService = appService;
        }

        [Route("app/dashboard")]
        public IActionResult dashboard()
        {
            var query = _appService.FetchAllPaymentRequest();
            var userClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StaffId");
           

            var allRequestCount = query.Count();
            var allApprovedRequest = query.Count(x=>x.ApprovalStatus==Guid.Parse(AppConstants.ApprovalStatus.APPROVED));
            var allRejectRequest = query.Count(x => x.ApprovalStatus == Guid.Parse(AppConstants.ApprovalStatus.REJECTED));

            var tenLatestRequests = query;
            if (!User.IsInRole("Management"))
            {
                tenLatestRequests = tenLatestRequests.Where(x => x.CreatedBy == Guid.Parse(userClaim.Value))
                    .OrderByDescending(x => x.RequestDate).Take(10);
            }
            else
            {
                tenLatestRequests = tenLatestRequests
                    .OrderByDescending(x => x.RequestDate).Take(10);
            }

            ViewBag.AllRequestCount = allRequestCount;
            ViewBag.AllApprovedRequestCount = allApprovedRequest;
            ViewBag.AllRejectedRequestCount = allRejectRequest;

            return View("Index",tenLatestRequests.ToList());
        }


        
        public IActionResult Index()
        {
            return RedirectToAction("dashboard");
        }

    }
}