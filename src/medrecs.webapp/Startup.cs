using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(medrecs.webapp.Startup))]
namespace medrecs.webapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
