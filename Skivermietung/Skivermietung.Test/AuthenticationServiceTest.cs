using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skivermietung.Business.Domain;
using Skivermietung.Business.Security;
using Skivermietung.Models;

namespace Skivermietung.Test
{
	[TestClass]
	public class AuthenticationServiceTest
	{
		private IUnitOfWork _unitOfWork;
		private AuthenticationService _testee;

		private const string Username = "Legend27";
		private const string Password = "pAss*/12";

		[TestInitialize]
		public void TestInitialize()
		{
			_unitOfWork = A.Fake<IUnitOfWork>();

			_testee = new AuthenticationService(_unitOfWork);
		}

		[TestMethod]
		public void Verify_WhenUserNotExists_ThenReturnFalse()
		{
			A.CallTo(() => _unitOfWork.Benutzer.LoadByUsername(Username)).Returns(null);

			var result = _testee.VerifyCredentials(Username, Password);

			result.Should().BeFalse();
		}

		[TestMethod]
		public void Verify_WhenCredentialsAreInvalid_ThenReturnFalse()
		{
			var user = new Benutzer
			{
				Benutzername = Username,
				PasswordHash = "SomeFancyHas123546asd43568",
				PasswordSalt = BCrypt.Net.BCrypt.GenerateSalt()
			};

			A.CallTo(() => _unitOfWork.Benutzer.LoadByUsername(Username)).Returns(user);

			var result = _testee.VerifyCredentials(Username, Password);

			result.Should().BeFalse();
		}

		[TestMethod]
		public void Verify_WhenCredentialsAreValid_ThenReturnTrue()
		{
			string salt = BCrypt.Net.BCrypt.GenerateSalt();
			string hash = BCrypt.Net.BCrypt.HashPassword(Password, salt);

			var user = new Benutzer
			{
				Benutzername = Username,
				PasswordHash = hash,
				PasswordSalt = salt
			};


			A.CallTo(() => _unitOfWork.Benutzer.LoadByUsername(Username)).Returns(user);

			var result = _testee.VerifyCredentials(Username, Password);

			result.Should().BeTrue();
		}
	}
}
