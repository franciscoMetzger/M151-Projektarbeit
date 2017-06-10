using System.Reflection;
using Autofac;
using Skivermietung.Business.Domain;
using Skivermietung.Business.Domain.Repositories;
using Skivermietung.Business.Domain.Repositories.Interfaces;
using Skivermietung.Business.Security;
using Skivermietung.Models;
using Module = Autofac.Module;

namespace Skivermietung.Business.Modules
{
	public class SkivermietungModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

			builder.RegisterType<SkivermietungContext>().AsSelf().InstancePerRequest();

			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.Where(t => t.Name.EndsWith("Repository"))
				.AsImplementedInterfaces();
		}
	}
}