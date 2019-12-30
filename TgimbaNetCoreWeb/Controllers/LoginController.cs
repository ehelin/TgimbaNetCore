using Microsoft.AspNetCore.Mvc;
using TgimbaNetCoreWebShared;
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
        public string Login(string user, string pass)
        {
            return sharedLoginController.Login(user, pass);
        } 
    }
}
