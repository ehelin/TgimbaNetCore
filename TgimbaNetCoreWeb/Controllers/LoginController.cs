using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		 					  
using TgimbaNetCoreWebShared;  	 					  
using TgimbaNetCoreWebShared.Models;
using TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWeb.Controllers
{
    #if !DEBUG
    [RequireHttpsAttribute]
    #endif
    public class LoginController : Controller
    {
		private SharedLoginController sharedLoginController = null;

        public LoginController(ITgimbaService_Old service, IWebClient webClient)
        {
			sharedLoginController = new SharedLoginController(service, webClient);
		}		  

        [HttpPost]
        public string Login(string user, string pass)
        {
            return sharedLoginController.Login(user, pass);
        } 
    }
}
