using Shared.dto;

namespace Shared.interfaces
{
    public interface IPassword
    {
        bool PasswordsMatch(string suppliedPassword, string dbSalt, string dbPassword);
        string GetSalt();
        Password HashPassword(Password np);
    }
}
