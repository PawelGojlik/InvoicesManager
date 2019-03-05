using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvoicesManager.Startup))]
namespace InvoicesManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
