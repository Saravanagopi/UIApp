using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIApp.Startup))]
namespace UIApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
