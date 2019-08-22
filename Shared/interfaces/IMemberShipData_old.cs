using Shared.dto;

namespace Shared.interfaces
{
    public interface IMemberShipData_Old
    {
        User GetUser(string userName);
        bool AddUser(string userName, string email, string passWord, string salt);
        bool DeleteUser(string userName, string passWord, string email);
        void LogMsg(string msg);
        void AddToken(string userName, string token);
    }
}
