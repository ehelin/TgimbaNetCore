using Shared.dto;

namespace Shared.interfaces
{
    public interface IPassword
    {
        bool PasswordsMatch(Password passwordDto, User user);
        string GetSalt();
        Password HashPassword(Password np);
    }
}
