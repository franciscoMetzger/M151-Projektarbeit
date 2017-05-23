using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Skivermietung.Startup))]
namespace Skivermietung
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
