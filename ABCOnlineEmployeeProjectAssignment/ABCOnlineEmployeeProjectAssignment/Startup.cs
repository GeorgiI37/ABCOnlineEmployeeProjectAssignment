using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABCOnlineEmployeeProjectAssignment.Startup))]
namespace ABCOnlineEmployeeProjectAssignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
