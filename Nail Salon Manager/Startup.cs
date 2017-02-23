using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nail_Salon_Manager.Startup))]
namespace Nail_Salon_Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
