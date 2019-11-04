using Microsoft.IdentityModel.Tokens;

namespace Shared.interfaces
{
    public interface IGenerator
    {
        string GetJwtPrivateKey(); 
        string GetJwtIssuer();
        string GetJwtToken(string jwtPrivateKey, string jwtIssuer, int tokenLife = Constants.TOKEN_LIFE);
        string[] GetValidTokenResponse();
        string[] GetInValidTokenResponse();
        SecurityToken DecryptJwtToken(string token);
    }
}
