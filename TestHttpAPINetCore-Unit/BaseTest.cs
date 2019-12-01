using Shared.dto.api;

namespace TestHttpAPINetCore_Unit
{
    public class BaseTest
    {
        protected TokenRequest SetTokenRequest(string userName = "userName", string token = "token")
        {
            var login = new TokenRequest()
            {
                EncodedUserName = userName,
                EncodedToken = token
            };

            return login;
        }

        protected LoginRequest SetLoginRequest(string userName = "userName", string password = "password")
        {
            var login = new LoginRequest()
            {
                EncodedUserName = userName,
                EncodedPassword = password
            };

            return login;
        }
    }
}
