using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScheduleWebApp.Startup))]
namespace ScheduleWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
