using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(identityTUtorial.Startup))]
namespace identityTUtorial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
