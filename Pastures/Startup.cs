using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pastures.Startup))]
namespace Pastures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
