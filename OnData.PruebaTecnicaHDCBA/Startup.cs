using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnData.PruebaTecnicaHDCBA.Startup))]
namespace OnData.PruebaTecnicaHDCBA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
