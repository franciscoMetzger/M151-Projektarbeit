using Autofac;
using Skivermietung.Business.Security;

namespace Skivermietung.Business.Modules
{
	public class SkivermietungModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
		}
	}
}