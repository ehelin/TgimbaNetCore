using Microsoft.AspNetCore.Mvc;	  			
using TgimbaNetCoreWeb.Models;
using Shared.interfaces;
using Microsoft.AspNetCore.Http;

namespace TgimbaNetCoreWeb.Controllers
{
    #if !DEBUG
    [RequireHttpsAttribute]
    #endif
    public class ReportController : Controller
    {
        private ITgimbaService_Old service = null;

        public ReportController(ITgimbaService_Old service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ReportIndexModel model)
        {
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.UserName)
                        && !string.IsNullOrEmpty(model.Password)
                            && model.UserName == Shared.Credentials.GetReportUser()
                                && model.Password == Shared.Credentials.GetReportPassword())
                {
                    HttpContext.Session.SetString("ReportToken", Shared.Credentials.GetReportToken());
                    return RedirectToAction("ReportDisplay");
                }
            }

            if (model == null)
            {
                model = new ReportIndexModel();
            }

            model.Error = "Login Failed";

            return View("Index", model);
        }

        public IActionResult ReportDisplay()
        {
            var token = HttpContext.Session.GetString("ReportToken");
            if (string.IsNullOrEmpty(token) || token != Shared.Credentials.GetReportToken())
            {
                return RedirectToAction("Index");
            }

            var model = new ReportDisplayModel();

            model.Report = this.service.GetReport();

            return View(model);
        }
    }
}