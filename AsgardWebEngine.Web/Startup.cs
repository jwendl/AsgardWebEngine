using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AsgardWebEngine.Web.Startup))]
namespace AsgardWebEngine.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
