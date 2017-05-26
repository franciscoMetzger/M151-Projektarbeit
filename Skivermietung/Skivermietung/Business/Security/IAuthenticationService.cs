namespace Skivermietung.Business.Security
{
	public interface IAuthenticationService
	{
		void Register(string username, string password, bool isAdmin);
		void ChangePassword(string username, string password);
		bool VerifyCredentials(string username, string password);
	}
}