using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;		 					  
using TgimbaNetCoreWebShared;  	 					  
using TgimbaNetCoreWebShared.Models;
using TgimbaNetCoreWebShared.Controllers;

namespace TgimbaNetCoreWebAngular6.Controllers
{
#if !DEBUG
    [RequireHttpsAttribute]
#endif
    public class LoginController : Controller
    {
        private SharedLoginController sharedLoginController = null;
        private IWebClient client;

        public LoginController(IWebClient webClient)
        {
            this.client = webClient;
            this.client.LogMessage("LoginController constructor");
            sharedLoginController = new SharedLoginController(webClient);
        }

        [HttpPost]
        public string Login([FromQuery] string encodedUser, string encodedPass)
        {
            this.client.LogMessage("LoginController Login(args)");
            return sharedLoginController.Login(encodedUser, encodedPass);
        }		
    }
}
