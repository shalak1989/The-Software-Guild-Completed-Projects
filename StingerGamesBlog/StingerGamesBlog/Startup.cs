using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StingerGamesBlog.Startup))]
namespace StingerGamesBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
