using Shared.dto;
using models = DALNetCore.Models;

namespace DALNetCore.interfaces
{
    public interface IUserHelper
    {
        User ConvertDbUserToUser(models.User dbUser);
    }
}
