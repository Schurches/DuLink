using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DuLink.Startup))]
namespace DuLink
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
