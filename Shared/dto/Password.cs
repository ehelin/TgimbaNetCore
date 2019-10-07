namespace Shared.dto
{
    public class Password
    {
        private string PassWord { get; set; }
        public string Salt { get; set; }
        public string SaltedHashedPassword { get; set; }

        public Password(string clearPass)
        {
            PassWord = clearPass;
        }

        public string GetSaltPassword()
        {
            return Salt + PassWord;
        }
    }
}
