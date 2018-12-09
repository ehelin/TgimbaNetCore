namespace Shared.interfaces
{
	public interface IWebClient
	{
		string Login(string encodedUser, string encodedPass);
		bool Registration(string encodedUser, string encodedEmail, string encodedPassword);
	}
}
