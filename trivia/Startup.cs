using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(trivia.Startup))]
namespace trivia
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
