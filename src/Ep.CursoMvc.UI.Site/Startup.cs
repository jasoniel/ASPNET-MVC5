using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ep.CursoMvc.UI.Site.Startup))]
namespace Ep.CursoMvc.UI.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
