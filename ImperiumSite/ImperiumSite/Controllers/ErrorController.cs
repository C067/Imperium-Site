using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ImperiumSite.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.Code = 404;
                    ViewBag.ErrorMessage = "Sorry but the page you are looking for does not exist, have been removed, name changed or is temporarily unavailable";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;
                    break;
                case 500:
                    ViewBag.Code = 500;
                    ViewBag.ErrorMessage = "Sorry something went wrong on the server";
                    //ViewBag.RouteOfException = statusCodeData.OriginalPath;
                    break;
            }

            return View("NotFound");
        }
    }
}