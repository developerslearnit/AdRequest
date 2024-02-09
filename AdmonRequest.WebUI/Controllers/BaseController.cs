using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdmonRequest.WebUI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
