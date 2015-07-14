using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSCS_MVC.Startup))]
namespace MSCS_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
