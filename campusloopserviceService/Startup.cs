using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(campusloopserviceService.Startup))]

namespace campusloopserviceService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}