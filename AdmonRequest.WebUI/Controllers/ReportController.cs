using AdmonRequest.Application.Constants;
using AdmonRequest.Application.Interfaces;
using AdmonRequest.WebUI.ReportParamsModel;
using AspNetCore.Reporting;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AdmonRequest.WebUI.Controllers
{
    [Route("reports")]
    public class ReportController : Controller
    {
        private readonly IAppService _appService;
        private readonly IWebHostEnvironment _env;
        public ReportController(IAppService appService, IWebHostEnvironment env)
        {
            _appService = appService;
            _env = env;
        }

        [HttpGet("request-report")]
        public IActionResult RequestReport()
        {
            return View();
        }

        [HttpPost("request-report/view")]
        public IActionResult RequestReportView(RequestReportParamModel model)
        {
            var paymentRequestQuery = _appService.FetchAllPaymentRequest();

            if (paymentRequestQuery == null) return Json(new
            {
                error = true,
                message = "Report Parameter is required"
            });

            //Report by Date range
           // var exMessage = string.Empty;

            try
            {
                if (model.ViewByDate)
                {
                    var stDate = model.StartDate;
                    var endDate = model.EndDate;

                    if (string.IsNullOrWhiteSpace(stDate) || string.IsNullOrWhiteSpace(endDate))
                    {
                        return Json(new
                        {
                            error = true,
                            message = "Start and End Date is required"
                        });
                    }

                    var startDate = new DateTime(int.Parse(stDate.Split("-")[2]), int.Parse(stDate.Split("-")[1]), int.Parse(stDate.Split("-")[0]));
                    var lastDate = new DateTime(int.Parse(endDate.Split("-")[2]), int.Parse(endDate.Split("-")[1]), int.Parse(endDate.Split("-")[0]));

                    if (startDate > lastDate)
                    {
                        return Json(new
                        {
                            error = true,
                            message = "Start cannot be greater than End Date"
                        });
                    }

                    paymentRequestQuery = paymentRequestQuery.Where(x => x.RequestDate >= startDate && x.RequestDate <= lastDate);

                }
                else if (model.ViewByStatus)
                {
                    var status = Guid.Parse(AppConstants.ApprovalStatus.PENDING);

                    if (model.Status == "approved")
                    {
                        status = Guid.Parse(AppConstants.ApprovalStatus.APPROVED);
                    }
                    else if (model.Status == "pending")
                    {
                        status = Guid.Parse(AppConstants.ApprovalStatus.PENDING);
                    }
                    else
                    {
                        status = Guid.Parse(AppConstants.ApprovalStatus.REJECTED);
                    }

                    paymentRequestQuery = paymentRequestQuery.Where(x => x.ApprovalStatus == status);
                }

                if (!paymentRequestQuery.Any())
                {
                    return Json(new
                    {
                        error = true,
                        message = "No record for the selected parameters"
                    });
                }

                var appRootPath = _env.ContentRootPath;

                var reportRootPath = Path.Combine(appRootPath, "Reports");


                string rdlcFilePath = Path.Combine(reportRootPath, "PaymentRequestReport.rdlc");
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding.GetEncoding("windows-1252");


                LocalReport report = new LocalReport(rdlcFilePath);

                report.AddDataSource("RequestReportDataSet", paymentRequestQuery.ToList());


                var result = report.Execute(RenderType.Pdf, 1);

                var resultBase64 = Convert.ToBase64String(result.MainStream);


                var embedFrame = "<iframe src=\"{0}\" width=\"800px\" height=\"450px\"></iframe>";

                var returnString = string.Format(embedFrame, $"data:application/pdf;base64,{Uri.EscapeDataString(resultBase64)}");


                return Json(new
                {
                    error = false,
                    data = returnString
                });
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

        [HttpGet("budget-summary")]
        public IActionResult BudgetSummary()
        {
            return View();
        }

        [HttpGet("ledger-report")]
        public IActionResult LedgerReport()
        {
            return View();
        }

        [HttpGet("subscriber-account-details")]
        public IActionResult SubscriberAccountDetails()
        {
            return View();
        }

        [HttpGet("consolidated-account-details")]
        public IActionResult ConsolidatedAccountDetails()
        {
            return View();
        }

        [HttpGet("budget-summary-and-amount-expended")]
        public IActionResult BudgetSummaryAndAmountExpended()
        {
            return View();
        }

        [HttpGet("trial-balance")]
        public IActionResult TrialBalance()
        {
            return View();
        }

        [HttpGet("financial-performance")]
        public IActionResult FinancialPerfomance()
        {
            return View();
        }

        [HttpGet("project-income")]
        public IActionResult ProjectIncome()
        {
            return View();
        }

    }
}
