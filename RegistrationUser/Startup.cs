using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationUser.Startup))]
namespace RegistrationUser
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
