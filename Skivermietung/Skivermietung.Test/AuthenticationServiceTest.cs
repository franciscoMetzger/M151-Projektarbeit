using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skivermietung.Business.Domain;
using Skivermietung.Business.Security;

namespace Skivermietung.Test
{
	[TestClass]
	public class AuthenticationServiceTest
	{
		private IUnitOfWork _unitOfWork;
		private AuthenticationService _testee;

		private const string Username = "Legend47";

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

			var result = _testee.VerifyCredentials(Username, "pass");

			result.Should().BeFalse();
		}
	}
}
