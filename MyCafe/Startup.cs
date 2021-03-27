using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCafe_v1._5.Startup))]
namespace MyCafe_v1._5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
