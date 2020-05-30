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

        public LoginController(IWebClient webClient)
        {
            sharedLoginController = new SharedLoginController(webClient);
        }

        [HttpPost]
        public string Login([FromQuery] string encodedUser, string encodedPass)
        {							 									 
            return sharedLoginController.Login(encodedUser, encodedPass);
        }		
    }
}
