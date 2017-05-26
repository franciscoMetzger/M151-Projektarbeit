namespace Skivermietung.Business.Security
{
	public interface IAuthenticationService
	{
		void SavePassword(string username, string password);
		bool VerifyCredentials(string username, string password);
	}
}