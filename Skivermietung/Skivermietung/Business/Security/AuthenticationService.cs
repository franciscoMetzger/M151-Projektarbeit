using System;

namespace Skivermietung.Business.Security
{
	public class AuthenticationService : IAuthenticationService
	{
		public void SavePassword(string username, string password)
		{
			string salt = BCrypt.Net.BCrypt.GenerateSalt();
			string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);


		}

		public bool VerifyCredentials(string username, string password)
		{
			throw new NotImplementedException();
		}
	}
}