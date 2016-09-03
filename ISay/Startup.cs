using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISay.Startup))]
namespace ISay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
