using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AdmonRequest.Application.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdmonRequest.WebUI.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserAccountService _accountService;

        public AuthController(IUserAccountService accountService)
        {
            _accountService = accountService;
        }

       

        [HttpGet("login")]
        public IActionResult Login(string returnUrl = "/")
        {
            var _url = returnUrl;

            return View();
        }



        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (string.IsNullOrWhiteSpace(model.username) || string.IsNullOrWhiteSpace(model.Password))
                return Json(new
                {
                    error = true,
                    message = "Please provide a valid password"
                });

            try
            {
                var user = await _accountService.FindUserByUserName(model.username);

                if (user == null)
                {
                    user = await _accountService.FindUserByStaffCode(model.username);
                }

                if (user == null) return Json(new
                {
                    error = true,
                    message = "User with the credentials was not found"
                });

                var passSalt = user.PasswordSalt;

                var newPassword = model.Password.EncryptSha512(passSalt);

                var passChanged = await _accountService.ChangePassword(user.StaffId, newPassword, DateTime.Now);

                if (!passChanged) return Json(new
                {
                    error = true,
                    message = "There was an error changing password"
                });

                return Json(new
                {
                    error = false,
                    message = "Password was changed successfully, proceed to login with the new credentials"
                });

            }
            catch (Exception)
            {
                return Json(new
                {
                    error = true,
                    message = "There was an error changing password"
                });
            }





        }


        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model)
        {


            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
                return Json(new
                {
                    error = true,
                    message = "Wrong username or password"
                });

            var user = await _accountService.FindUserByUserName(model.Username);

            if (user == null)
            {
                user = await _accountService.FindUserByStaffCode(model.Username);
            }

            if (user == null) return Json(new
            {
                error = true,
                message = "Wrong username or password"
            });


            if(!user.ActiveStatus) return Json(new
            {
                error = true,
                message = "Your account has been disabled please contact your administrator"
            });


            if (string.IsNullOrWhiteSpace(user.PasswordSalt))
            {
                var passSalt = DateTime.Now.Ticks.ToString().Right(10).EncryptSha512();
                var newPassword = model.Password.EncryptSha512(passSalt);

                await _accountService.GenerateDefualtPassword(user.StaffId, newPassword, passSalt);

                return Json(new
                {
                    error = false,
                    requirePasswordChange = true,
                    staffId = model.Username,
                    message = ""
                });
            }


            var password = model.Password.EncryptSha512(user.PasswordSalt);

            if (!password.Equals(user.Password)) return Json(new
            {
                error = true,
                message = "Wrong username or password"
            });

            var staffApprovalLevel = user.ApprovalStage.HasValue ? user.ApprovalStage.Value : Guid.Empty;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName,user.StaffName),
                new Claim("StaffId",user.StaffId.ToString()),
                new Claim(ClaimTypes.Name,model.Username),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("ApprovalLevel",staffApprovalLevel.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                principal, new AuthenticationProperties { IsPersistent = true });

            return Json(new
            {
                error = false,
                message = "",
                staffId = model.Username,
                requirePasswordChange = !user.LastPasswordChangeDate.HasValue,
            });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }
    }
}
