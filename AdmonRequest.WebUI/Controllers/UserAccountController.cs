using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdmonRequest.WebUI.Controllers
{
    [Route("app")]
    public class UserAccountController : BaseController
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IAppService _appService;
        public UserAccountController(IUserAccountService userAccountService, IAppService appService)
        {
            _userAccountService = userAccountService;
            _appService = appService;
        }

        [Route("users")]
        public IActionResult Index()
        {
            var approvalStages = _appService.FetchApprovalLevel();
            ViewBag.ApprovalStages = new SelectList(approvalStages, "Id", "Name");
            return View();
        }

        [HttpPost]
        [Route("users/all/show")]
        public IActionResult ListAllUsers()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var search = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();


            //Custom seach params
            var staffName = Request.Form["columns[1][search][value]"].FirstOrDefault();
            var staffCode = Request.Form["columns[2][search][value]"].FirstOrDefault();
            var email = Request.Form["columns[3][search][value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var query = _userAccountService.FindAllUsers();

            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //{
            //    //var propertyInfo = typeof(AccountControlModel).GetProperty(sortColumn);

            //    if (sortColumn == "dateCreated")
            //    {
            //        if (sortColumnDirection == "asc")
            //        {

            //            query = query.AsQueryable().OrderBy(x => x.RequestDate);
            //        }
            //        else
            //        {
            //            query = query.AsQueryable().OrderByDescending(x => x.RequestDate);
            //        }
            //    }

            //}

            if (!string.IsNullOrWhiteSpace(staffName))
            {
                query = query.Where(x => x.StaffName.ToLower().StartsWith(staffName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(staffCode))
            {
                query = query.Where(x => x.StaffCode.ToLower().StartsWith(staffCode.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(x => x.Email.ToLower().StartsWith(email.ToLower()));
            }


            recordsTotal = query.Count();

            var paymentRequests = query
                .Skip(skip).Take(pageSize);

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = paymentRequests.ToList()
            });
        }

        [HttpPost("user/update")]
        public async Task<IActionResult> UpdateUser(UserAccountModel model)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(model.Email))
                {
                    return Json(new
                    {
                        error = true,
                        message = "Email is required"
                    });
                }

                var updated = await _userAccountService.UpdateUser(model);

                if (updated)
                {
                    return Json(new
                    {
                        error = false,
                        message = "User updated successfully"
                    });
                }
                else
                {
                    return Json(new
                    {
                        error = true,
                        message = "There was an error updating user"
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = true,
                    message = ex.Message
                });
            }
         

            
        }



    }
}
