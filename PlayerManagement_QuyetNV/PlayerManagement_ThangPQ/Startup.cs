using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayerManagement_ThangPQ.Startup))]
namespace PlayerManagement_ThangPQ
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
