using Autofac;
using Skivermietung.Business.Domain.Repositories;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Business.Security;

namespace Skivermietung.Business.Modules
{
	public class SkivermietungModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();

			builder.RegisterType<BenutzerRepository>().As<IBenutzerRepository>();
		}
	}
}