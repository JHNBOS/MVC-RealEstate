using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealEstateMVC.Startup))]
namespace RealEstateMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
