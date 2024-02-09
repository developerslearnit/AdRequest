using AdmonRequest.Application.Interfaces;
using AdmonRequest.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdmonRequest.WebUI.Controllers
{
    [Route("setup")]
    public class SetupController : BaseController
    {
        private readonly IAppService _appService;
        public SetupController(IAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("request-types")]
        public IActionResult RequestTypes()
        {
            return View();
        }

        [HttpPost("request-types/new")]
        public async Task<IActionResult> AddRequestTypes(RequestTypeModel model)
        {


            if (string.IsNullOrEmpty(model.Name)) return Json(new
            {
                error = true,
                message = "Request type name is required"
            });
            bool isUpdate = model.RequestTypeId != Guid.Empty;

            try
            {

                if (!isUpdate)
                {
                    var typeExists = _appService.FetchRequestTypes()
                                        .Any(x => x.Name == model.Name);

                    if (typeExists) return Json(new
                    {
                        error = true,
                        message = $"{model.Name} already exists"
                    });
                }
                

                var isAdded = await _appService.AddNewRequestType(model);

                if (isAdded)
                {
                    return Json(new
                    {
                        error = false,
                        message = "Request type was created"
                    });
                }
                else
                {
                    return Json(new
                    {
                        error = true,
                        message = "There was an error creating request type"
                    });
                }

            }
            catch (Exception)
            {
                return Json(new
                {
                    error = true,
                    message = "Internal Server Error"
                });
            }

           
        }

        
        [HttpPost]
        [Route("request-types/all/show")]
        public IActionResult ListAllRequestTypes()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var search = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            //Custom seach params
            var requestName = Request.Form["columns[1][search][value]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var query = _appService.FetchRequestTypes();

            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //{
            //    //var propertyInfo = typeof(AccountControlModel).GetProperty(sortColumn);

            //    if (sortColumnDirection == "asc")
            //    {

            //        query = query.AsQueryable().OrderBy(x => EF.Property<object>(x, sortColumn));
            //    }
            //    else
            //    {
            //        query = query.AsQueryable().OrderByDescending(x => EF.Property<object>(x, sortColumn));
            //    }

            //}

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query
                    .Where(x => x.Name.ToLower().Contains(search.ToLower())
                    );
            }

            if (!string.IsNullOrWhiteSpace(requestName))
            {
                query = query.Where(x => x.Name.ToLower().StartsWith(requestName.ToLower()));
            }
                       

            recordsTotal = query.Count();

            var requestTpes = query
                .Skip(skip).Take(pageSize);

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = requestTpes.ToList()
            });
        }


    }
}
