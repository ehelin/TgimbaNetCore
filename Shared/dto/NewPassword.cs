namespace Shared.dto
{
    public class NewPassword
    {
        private string Password { get; set; }
        public string Salt { get; set; }
        public string SaltedHashedPassword { get; set; }

        public NewPassword(string clearPass)
        {
            Password = clearPass;
        }

        public string GetSaltPassword()
        {
            return Salt + Password;
        }
    }
}
