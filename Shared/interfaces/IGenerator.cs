namespace Shared.interfaces
{
    public interface IGenerator
    {
        string GetJwtPrivateKey(); 
        string GetJwtIssuer();
        string GetJwtToken(string jwtPrivateKey, string jwtIssuer);
    }
}
