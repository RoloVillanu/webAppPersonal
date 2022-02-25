using Microsoft.Owin;
using Owin;
using webAppPersonal.BL.Data;

[assembly: OwinStartup(typeof(webAppPersonal.API.Startup))]

namespace webAppPersonal.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Permite configurar el dbContext para usarlo como una unica instancia Singleton 
            // por request
            app.CreatePerOwinContext(webAppPersonalContext.Create);            
        }
    }
}
