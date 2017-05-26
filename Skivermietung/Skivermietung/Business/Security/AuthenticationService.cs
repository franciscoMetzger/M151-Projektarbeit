using System;
using Skivermietung.Business.Domain;
using Skivermietung.Models;
using Crypt = BCrypt.Net.BCrypt;

namespace Skivermietung.Business.Security
{
	internal class AuthenticationService : IAuthenticationService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AuthenticationService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Register(string username, string password, bool isAdmin)
		{
			if (_unitOfWork.Benutzer.Exists(username))
			{
				throw new InvalidOperationException(string.Format("Es existiert bereits ein Benutzer mit dem Benutzernamen \"{0}\"!", username));
			}

			string salt = Crypt.GenerateSalt();
			string hash = Crypt.HashPassword(password, salt);

			var user = new Benutzer
			{
				Benutzername = username,
				IsAdmin = isAdmin,
				PasswordHash = hash,
				PasswordSalt = salt
			};

			_unitOfWork.Benutzer.Insert(user);
			_unitOfWork.SaveChanges();
		}

		public void ChangePassword(string username, string password)
		{
			if (_unitOfWork.Benutzer.Exists(username) == false)
			{
				throw new InvalidOperationException(string.Format("Es existiert kein Benutzer mit dem Benutzernamen \"{0}\"!", username));
			}

			string salt = Crypt.GenerateSalt();
			string hash = Crypt.HashPassword(password, salt);

			var user = _unitOfWork.Benutzer.LoadByUsername(username);

			user.PasswordSalt = salt;
			user.PasswordHash = hash;

			_unitOfWork.Benutzer.Update(user);
			_unitOfWork.SaveChanges();
		}

		public bool VerifyCredentials(string username, string password)
		{
			var user = _unitOfWork.Benutzer.LoadByUsername(username);
			if (user == null)
			{
				return false;
			}

			return Crypt.Verify(password, user.PasswordSalt);
		}
	}
}