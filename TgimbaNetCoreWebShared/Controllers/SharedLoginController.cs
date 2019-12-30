using Shared.interfaces;		
using TgimbaNetCoreWebShared.Models;	   
using Microsoft.AspNetCore.Mvc;

namespace TgimbaNetCoreWebShared.Controllers
{
    public class SharedLoginController : SharedBaseController
    {
       public SharedLoginController(IWebClient webClient)
            : base(webClient) { }

        [HttpPost]
        public string Login(string user, string pass)
        {
            string token = this.webClient.Login(user, pass);

            return token;
        }
    }
}