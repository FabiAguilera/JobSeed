using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobSeed.WebMVC.Startup))]
namespace JobSeed.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
