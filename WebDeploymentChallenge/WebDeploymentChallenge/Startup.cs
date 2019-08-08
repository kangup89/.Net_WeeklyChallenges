using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebDeploymentChallenge.Startup))]
namespace WebDeploymentChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
