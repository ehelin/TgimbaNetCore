using Microsoft.AspNetCore.Mvc;	  			
using TgimbaNetCoreWeb.Models;
using Shared.interfaces;

namespace TgimbaNetCoreWeb.Controllers
{			 
	//[RequireHttpsAttribute]
    public class ReportController : Controller
    {
        private ITgimbaService service = null;

        public ReportController(ITgimbaService service)
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
            if(model != null)
            {
                if (!string.IsNullOrEmpty(model.UserName) 
                        && !string.IsNullOrEmpty(model.Password)
                            && model.UserName == Shared.Credentials.GetReportUser()
                                && model.Password == Shared.Credentials.GetReportPassword())
                {
                    return RedirectToAction("ReportDisplay");
                }
                
            }

            model = model == null ? new ReportIndexModel() : model;
            model.Error = "Login Failed";

            return View("Index", model);
        }

        public IActionResult ReportDisplay()
        {
            var model = new ReportDisplayModel();

            model.Report = this.service.GetReport();

            return View(model);
        }
    }
}