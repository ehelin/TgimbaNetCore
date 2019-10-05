using Shared.dto;
using DALNetCore.interfaces;
using models = DALNetCore.Models;

namespace DALNetCore.helpers
{
    public class UserHelper : IUserHelper
    {
        public User ConvertDbUserToUser(models.User dbUser)
        {
            var user = new User()
            {
                UserId = dbUser.UserId,
                UserName = dbUser.UserName,
                Salt = dbUser.Salt,
                Password = dbUser.PassWord,
                Email = dbUser.Email,
                Token = dbUser.Token
            };

            return user;
        }
    }
}
