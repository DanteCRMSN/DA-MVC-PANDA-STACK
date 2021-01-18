using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PANDA_MVC_V5.Startup))]
namespace PANDA_MVC_V5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
