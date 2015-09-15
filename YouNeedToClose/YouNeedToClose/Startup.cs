using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YouNeedToClose.Startup))]
namespace YouNeedToClose
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
