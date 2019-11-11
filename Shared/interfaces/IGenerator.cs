using Microsoft.IdentityModel.Tokens;

namespace Shared.interfaces
{
    public interface IGenerator
    {
        string GetJwtPrivateKey(); 
        string GetJwtIssuer();
        string GetJwtToken(string jwtPrivateKey, string jwtIssuer, int tokenLife = Constants.TOKEN_LIFE);
        SecurityToken DecryptJwtToken(string token);

        // TODO - remove any methods below this comment and any tests
        //string[] GetValidTokenResponse();
        //string[] GetInValidTokenResponse();
    }
}
