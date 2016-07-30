using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaseballLeague.Startup))]
namespace BaseballLeague
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
