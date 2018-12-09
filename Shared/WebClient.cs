using Shared.interfaces;

namespace Shared
{
    public class WebClient : IWebClient
    {
        private ITgimbaService service = null;

        public WebClient(ITgimbaService service)
        {
            this.service = service;
        }

        public string Login(string encodedUser, string encodedPass)
        {
            string token = string.Empty;

            token = service.ProcessUser(encodedUser, encodedPass);

            return token;
        }

		// Encrypt username/email/password/and all data points
		public bool Registration(
			string encodedUser, 
			string encodedEmail, 
			string encodedPassword
		) {
			bool registered = false;

			registered = service.ProcessUserRegistration(encodedUser, encodedEmail, encodedPassword);

			return registered;
		} 
	}
}
