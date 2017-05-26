using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skivermietung.Business.Security;

namespace Skivermietung.Test
{
	[TestClass]
	public class AuthenticationServiceTest
	{
		private AuthenticationService _testee;

		[TestInitialize]
		public void TestInitialize()
		{
			_testee = new AuthenticationService();
		}

		[TestMethod]
		public void SavePassword()
		{

			_testee.SavePassword("User", "passL");

		}
	}
}
