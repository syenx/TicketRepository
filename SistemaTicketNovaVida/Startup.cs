using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaTicketNovaVida.Startup))]
namespace SistemaTicketNovaVida
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
