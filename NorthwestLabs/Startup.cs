using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NorthwestLabs.Startup))]
namespace NorthwestLabs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
