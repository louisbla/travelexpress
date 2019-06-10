using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelExpress5.Startup))]
namespace TravelExpress5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
