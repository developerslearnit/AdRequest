using Microsoft.AspNetCore.Mvc;

namespace AdmonRequest.WebUI.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {

        [HttpGet("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
