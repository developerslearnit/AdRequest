using AdmonRequest.Application.Common;
using AdmonRequest.Application.Constants;
using AdmonRequest.Application.Email;
using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;
using AdmonRequest.WebUI.Helpers;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace AdmonRequest.WebUI.Controllers
{
    [Route("app")]
    public class AppRequestController : BaseController
    {
        private readonly IAppService _appService;
        private readonly IUserAccountService _userService;
        private readonly INotificationService _notificationService;
        private readonly IMailNotification _mailNotification;
        IWebHostEnvironment _env;
        IConfiguration _config;
        public AppRequestController(IAppService appService, IUserAccountService userService, INotificationService notificationService, IWebHostEnvironment env, IConfiguration config, IMailNotification mailNotification)
        {
            _appService = appService;
            _userService = userService;
            _notificationService = notificationService;
            _env = env;
            _config = config;
            _mailNotification = mailNotification;
        }

        [HttpGet("requests")]
        public IActionResult Index()
        {
            var reqTypes = _appService.FetchRequestTypes()
                .Select(x => new
                {
                    id = x.RequestTypeId,
                    name = x.Name

                });

            var departments = _appService.FetchDepartment();
            var budgetCat = _appService.FetchBudgetCategory();
            var budgetYear = _appService.FetchBudgetYear();
            var beneficiaries = _userService.FindAllUsers()
                .Select(x => new
                {
                    id = x.StaffId,
                    name = x.StaffName
                });
            ViewBag.Departments = new SelectList(departments, "Id", "Name");
            ViewBag.BudgetCat = new SelectList(budgetCat, "Id", "Name");
            ViewBag.RequestTypes = new SelectList(reqTypes, "id", "name");
            ViewBag.BudgetYear = new SelectList(budgetYear, "Id", "Name");
            ViewBag.Beneficiaries = new SelectList(beneficiaries, "id", "name");

            return View();
        }

        [HttpGet("requests/type")]
        public IActionResult CheckRequestType(Guid requestTypeId)
        {
            var requestType = _appService.FetchRequestTypes().FirstOrDefault(x => x.RequestTypeId == requestTypeId);

            return Json(new
            {
                error = false,
                data = requestType
            });
        }

        [HttpGet("subunit/deptId")]
        public IActionResult GetSubUnitByDepartment(Guid deptId)
        {
            var subDepartment = _appService.FetchSubUnit(deptId);

            return Json(new
            {
                error = false,
                data = subDepartment
            });
        }

        [HttpGet("budget-period/yearId")]
        public IActionResult GetBudgetPeriodByYear(Guid yearId)
        {
            var budgetPeriod = _appService.FetchBudgetPeriod(yearId);

            return Json(new
            {
                error = false,
                data = budgetPeriod
            });
        }

        [HttpGet("budget-details/filter")]
        public IActionResult FilterBudgetDetails(string yearId, string periodId, string dept, string subDept)
        {
            var budgetDetails = _appService.FetchAllBudgetDetails()
                .Where(x => x.BudgetYearId.ToString() == yearId
                && x.BudgetPeriodId.ToString() == periodId
                && x.DepartmentId.ToString() == dept).ToList();

            return Json(new
            {
                error = false,
                data = budgetDetails
            });
        }

        [HttpPost]
        [Route("request/all/show")]
        public IActionResult ListAllPaymentRequest()
        {           

            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var search = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();


            //Custom seach params
            var requestType = Request.Form["columns[1][search][value]"].FirstOrDefault();
            var beneficiaryName = Request.Form["columns[2][search][value]"].FirstOrDefault();
            var deptUnit = Request.Form["columns[3][search][value]"].FirstOrDefault();
            var refNumber = Request.Form["columns[4][search][value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var query = _appService.FetchAllPaymentRequest();

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                //var propertyInfo = typeof(AccountControlModel).GetProperty(sortColumn);

                if (sortColumn == "dateCreated")
                {
                    if (sortColumnDirection == "asc")
                    {

                        query = query.AsQueryable().OrderBy(x => x.RequestDate);
                    }
                    else
                    {
                        query = query.AsQueryable().OrderByDescending(x => x.RequestDate);
                    }
                }

            }

            if (!string.IsNullOrWhiteSpace(requestType))
            {
                query = query.Where(x => x.RequestType.ToLower().StartsWith(requestType.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(beneficiaryName))
            {
                query = query.Where(x => x.Beneficiary.ToLower().StartsWith(beneficiaryName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(deptUnit))
            {
                query = query.Where(x => x.SubDepartment.ToLower().StartsWith(deptUnit.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(refNumber))
            {
                query = query.Where(x => x.RefNo.ToLower().StartsWith(refNumber.ToLower()));
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


        [HttpPost("staff-request/add")]
        public async Task<IActionResult> AddPaymentRequest(PaymentRequestModel model)
        {

            var exMessage = string.Empty;

            if (model.Amount <= 0) return Json(new
            {
                error = true,
                message = "Amount request must be greater than zero",

            });

            try
            {

                var isNewRequest = model.PaymentRequestId == Guid.Empty ? true : false;

                if (isNewRequest)
                {
                    model.RefNo = $"REF/01/022/{DateTime.Now.Ticks.ToString().Right(6)}";
                    model.ApprovalStatus = Guid.Parse(AppConstants.ApprovalStatus.PENDING);

                    var strData = model.RequestDateString.Split("-");
                    Guid userId = Guid.Empty;
                    model.RequestDate = new DateTime(int.Parse(strData[2]), int.Parse(strData[1]), int.Parse(strData[0]));
                    var userClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StaffId");

                    if (userClaim != null)
                    {
                        userId = Guid.Parse(userClaim.Value);
                    }

                    model.CreatedBy = userId;
                    var approvalStage = _appService.FetchAllApprovalStages().OrderBy(x => x.Level).Take(1).FirstOrDefault();

                    if (approvalStage != null)
                    {
                        model.ApprovalLevel = approvalStage.ApprovalStageId;
                    }
                }

                var inserted = await _appService.AddNewPaymentRequest(model);

                if (inserted.Item1)
                {
                    //if it's an update email is not needed
                    if (!isNewRequest)
                    {
                        return Json(new
                        {
                            error = false,
                            message = "Request was submitted successfully",
                            requestId = inserted.Item2
                        });
                    }

                    var managementStaffs = _userService.FindAllUsers().Where(r => r.Role == AppConstants.UserRoles.MANAGEMENTSTAFF).ToList();

                    if (managementStaffs.Any())
                    {
                        var templateHelper = new EmailTemplateBuilder(_env);
                        var mailBody = templateHelper.BuildNewRequestTemplate();
                        var mgtEmails = managementStaffs
                            .Select(x => x.Email).ToList().ToSemicolonSeparated();


                        var newEmail = new EmailWorkerModel
                        {
                            Body = mailBody,
                            FromAddress = "admonrequest@admon.com",
                            ToAddress = mgtEmails,
                            Subject = "New Request Notification"
                        };

                        var mailId = await _notificationService.AddNewEmailNotification(newEmail);
                        var apiKey = _config.GetValue<string>("EMailAPIKey");

                        BackgroundJob.Enqueue(() => _mailNotification.QueueEmail(mailId));

                        return Json(new
                        {
                            error = false,
                            message = "Request was submitted successfully",
                            requestId = inserted.Item2
                        });
                    }

                }
                else
                {
                    return Json(new { error = true, message = "There was an error creating request" });
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;

            }

            return Json(new
            {
                error = false,
                message = exMessage,
            });


        }

        [Authorize(Roles = "Management")]
        [HttpGet("requests/approvals")]
        public IActionResult RequestApproval()
        {
            return View();
        }

        [HttpPost]
        [Route("requests/approval/show")]
        public IActionResult ListAllPaymentRequestForApprovals()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var search = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            //Custom seach params
            var requestType = Request.Form["columns[1][search][value]"].FirstOrDefault();
            var beneficiaryName = Request.Form["columns[2][search][value]"].FirstOrDefault();
            var deptUnit = Request.Form["columns[3][search][value]"].FirstOrDefault();
            var refNumber = Request.Form["columns[4][search][value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var status = Guid.Parse(AppConstants.ApprovalStatus.PENDING);
            var staffId = Guid.Empty;
            var userClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "StaffId");

            staffId = userClaim != null ? Guid.Parse(userClaim.Value) : Guid.Empty;

            var staffApprovalLevel = _userService.FindAllUsers().FirstOrDefault(x => x.StaffId == staffId);

            var query = _appService.FetchAllPaymentRequest().Where(x => x.ApprovalStatus == status && x.ApprovalStage == staffApprovalLevel.ApprovalStage);

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                //var propertyInfo = typeof(AccountControlModel).GetProperty(sortColumn);

                if (sortColumn == "dateCreated")
                {
                    if (sortColumnDirection == "asc")
                    {

                        query = query.AsQueryable().OrderBy(x => x.RequestDate);
                    }
                    else
                    {
                        query = query.AsQueryable().OrderByDescending(x => x.RequestDate);
                    }
                }

            }


            if (!string.IsNullOrWhiteSpace(requestType))
            {
                query = query.Where(x => x.RequestType.ToLower().StartsWith(requestType.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(beneficiaryName))
            {
                query = query.Where(x => x.Beneficiary.ToLower().StartsWith(beneficiaryName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(deptUnit))
            {
                query = query.Where(x => x.SubDepartment.ToLower().StartsWith(deptUnit.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(refNumber))
            {
                query = query.Where(x => x.RefNo.ToLower().StartsWith(refNumber.ToLower()));
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


        [HttpGet("request/document/id")]
        public IActionResult FetchRequestDocument(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return Json(new
                {
                    error = true,
                    message = "Request id could not be found, hence document will not be uploaded",
                    data = ""
                });
            }


            if (!Guid.TryParse(id, out var requestId))
            {
                return Json(new
                {
                    error = true,
                    message = "Document request Id must be a valid GUID",
                    data = ""
                });
            }

            //var requestId = Guid.Parse(id);

            var doc = _appService.FetchRequestAttachment(requestId);

            if (doc == null)
            {
                return Json(new
                {
                    error = true,
                    message = "",
                });
            }


            doc.FileName = doc.Attachment.BytesToBase64String();
            var returnString = string.Empty;

            if (doc.FileExt.ToLower() == ".pdf")
            {
                var embedFrame = "<iframe src=\"{0}\" width=\"750px\" height=\"500px\"></iframe>";

                returnString = string.Format(embedFrame, $"data:application/pdf;base64,{Uri.EscapeDataString(doc.FileName)}");

            }
            else
            {
                var imgType = doc.FileExt.ToLower().Substring(1);

                returnString = $"<img src='data:image/${imgType};base64,${doc.FileName}'/>";
            }



            return Json(new
            {
                error = false,
                message = "",
                data = new
                {
                    mimeType = doc.FileExt,
                    document = returnString
                }
            });

        }


        [HttpPost("request/approve/do")]
        public async Task<IActionResult> ApproveRequest(ApprovalModel model)
        {
            Guid approvalStatus = Guid.Empty;

            var message = string.Empty;

            if (model.action == "Approved")
            {
                approvalStatus = Guid.Parse(AppConstants.ApprovalStatus.APPROVED);
                message = "Payment was approved successfully";
            }
            else
            {
                approvalStatus = Guid.Parse(AppConstants.ApprovalStatus.REJECTED);
            }

            var response = await _appService.ApproveOrDisaproveRequest(Guid.Parse(model.requestId), approvalStatus, "");

            if (response)
            {
                return Json(new
                {
                    error = false,
                    message = message
                });
            }

            return Json(new
            {
                error = true,
                message = "There was an error during the last operation"
            });

        }

        [HttpPost]
        [Route("request/upload/document")]
        public async Task<IActionResult> UploadRequestDocument()
        {

            var exMessage = string.Empty;

            try
            {
                var form = HttpContext.Request.Form;

                if (!form.Files.Any()) return Json(new
                {
                    error = true,
                    message = "You did not upload a valid file"
                });

                var requestId = form["requestId"].FirstOrDefault();

                if (requestId == null) return Json(new
                {
                    error = true,
                    message = "The payment request is invalid"
                });

                if (!Guid.TryParse(requestId, out var reqId))
                {
                    return Json(new
                    {
                        error = true,
                        message = $"Document request Id must be a valid GUID:: {requestId}",
                        data = ""
                    });
                }

                var formFile = form.Files[0];

                var allowedFiles = new string[] { ".pdf", ".jpg", ".jpeg", ".png" };
                var fileExt = Path.GetExtension(formFile.FileName);

                var isValidFile = fileExt.IsAllowedFileType(allowedFiles);

                if (!isValidFile) return Json(new
                {
                    error = true,
                    message = $"Invalid file selected. You can only upload file with these extensions {string.Join(",", allowedFiles)}"
                });

                await using var memoryStream = new MemoryStream();
                await formFile.CopyToAsync(memoryStream);
                var formByteArr = memoryStream.ToArray();


                var attachModel = new RequestAttachmentModel()
                {
                    Attachment = formByteArr,
                    FileExt = fileExt,
                    PaymentRequestId = reqId

                };

                var response = await _appService.AddRequestDocument(attachModel);

                if (response) return Json(new
                {
                    error = false,
                    //message = $"Invalid file selected. You can only upload file with these extensions {string.Join(",", allowedFiles)}"
                });

                return Json(new
                {
                    error = true,
                    message = "There was an error uploading the required document"
                });

            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            return Json(new
            {
                error = true,
                message = exMessage
            });



        }
    


    [HttpGet("Realtors")]
    public IActionResult RealtorsRegistration()
    {
        //var reqTypes = _appService.FetchRequestTypes()
        //    .Select(x => new
        //    {
        //        id = x.RequestTypeId,
        //        name = x.Name
        //    });

        //var departments = _appService.FetchDepartment();
        //var budgetCat = _appService.FetchBudgetCategory();
        //var budgetYear = _appService.FetchBudgetYear();
        //var beneficiaries = _userService.FindAllUsers()
        //    .Select(x => new
        //    {
        //        id = x.StaffId,
        //        name = x.StaffName
        //    });
        //ViewBag.Departments = new SelectList(departments, "Id", "Name");
        //ViewBag.BudgetCat = new SelectList(budgetCat, "Id", "Name");
        //ViewBag.RequestTypes = new SelectList(reqTypes, "id", "name");
        //ViewBag.BudgetYear = new SelectList(budgetYear, "Id", "Name");
        //ViewBag.Beneficiaries = new SelectList(beneficiaries, "id", "name");

        return View();
    }


        [HttpPost]
        [Route("Realtors/all/show")]
        public IActionResult ListAllReators()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var search = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();


            //Custom seach params
            var personRegistrationNo = Request.Form["columns[1][search][value]"].FirstOrDefault();
            var personName = Request.Form["columns[2][search][value]"].FirstOrDefault();
            var email = Request.Form["columns[3][search][value]"].FirstOrDefault();
            var phone = Request.Form["columns[4][search][value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var query = _appService.FetchAllPersonRegistration( 1);

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                //var propertyInfo = typeof(AccountControlModel).GetProperty(sortColumn);

                if (sortColumn == "personName")
                {
                    if (sortColumnDirection == "asc")
                    {

                        query = query.AsQueryable().OrderBy(x => x.PersonName);
                    }
                    else
                    {
                        query = query.AsQueryable().OrderByDescending(x => x.PersonRegistrationNo);
                    }
                }

            }



            if (!string.IsNullOrWhiteSpace(personRegistrationNo))
            {
                query = query.Where(x => x.PersonRegistrationNo.ToString().ToLower().StartsWith(personRegistrationNo.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(personName))
            {
                query = query.Where(x => x.PersonName.ToLower().StartsWith(personName.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(x => x.Email.ToLower().StartsWith(email.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query = query.Where(x => x.Phone.ToLower().StartsWith(phone.ToLower()));
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
    }


}
