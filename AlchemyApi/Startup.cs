using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlchemyApi.Startup))]
namespace AlchemyApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
