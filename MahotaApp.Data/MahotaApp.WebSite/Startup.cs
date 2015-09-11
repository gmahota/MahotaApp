using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MahotaApp.WebSite.Startup))]
namespace MahotaApp.WebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
