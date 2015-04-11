using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcEjemplo.Startup))]
namespace MvcEjemplo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
