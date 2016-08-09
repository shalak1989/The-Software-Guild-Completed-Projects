using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogTestApp.Startup))]
namespace BlogTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
