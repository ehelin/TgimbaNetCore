namespace Shared.dto
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
