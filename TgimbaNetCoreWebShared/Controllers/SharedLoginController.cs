using Shared.interfaces;		
using TgimbaNetCoreWebShared.Models;	   
using Microsoft.AspNetCore.Mvc;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedLoginController : SharedBaseController
    {
       public SharedLoginController(ITgimbaService service, IWebClient webClient)
            : base(service, webClient) { }

        [HttpPost]
        public string Login(string user, string pass)
        {
            string token = this.webClient.Login(user, pass);

            return token;
        }
   
        [HttpPost]
        public string JQueryLogin([FromBody] SharedLoginModel login)
        {
            string token = this.webClient.Login(login.Username, login.Password);

            return token;
        }
    }
}