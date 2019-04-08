using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlanilhaEletronicaWeb.Startup))]
namespace PlanilhaEletronicaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
