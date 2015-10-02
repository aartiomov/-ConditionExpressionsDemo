using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicExpressionsSample.Startup))]
namespace DynamicExpressionsSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
