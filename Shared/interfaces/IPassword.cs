using Shared.dto;

namespace Shared.interfaces
{
    public interface IPassword
    {
        bool PasswordsMatch(Password passwordDto, User user);
        string GetSalt(int size);
        Password HashPassword(Password np);
        bool ContainsOneNumber(string password);
        bool IsValidToken(User user, string token);
        bool IsValidUserToRegister(string user, string email, string password);
    }
}
