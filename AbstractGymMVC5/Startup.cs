using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbstractGymMVC5.Startup))]
namespace AbstractGymMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
