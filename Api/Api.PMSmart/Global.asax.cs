using System.Web.Http;

namespace Api.PMSmart
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(ServerConfig.Configure);
        }
    }
}