using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevOps_123.Startup))]
namespace DevOps_123
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
