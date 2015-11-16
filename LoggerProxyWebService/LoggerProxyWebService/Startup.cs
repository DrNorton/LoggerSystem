using System.Threading.Tasks;
using System.Web.Http;
using Castle.Windsor;
using LoggerProxyWebService;
using LoggerProxyWebService.DependencyInjection;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Owin;
using RabbitMQ.Client;


[assembly: OwinStartup(typeof(Startup))]
namespace LoggerProxyWebService
{

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            var container = ConfigureWindsor(GlobalConfiguration.Configuration);
            
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, container));
           
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);

             var hubConfiguration = new HubConfiguration
                {
                    Resolver = GlobalHost.DependencyResolver,
                    EnableJSONP = true,
                };
                map.RunSignalR(hubConfiguration);
            });

        }

     

        public static IWindsorContainer ConfigureWindsor(HttpConfiguration configuration)
        {
            var container = CastleInstaller.Install();
           
            var dependencyResolver = new WindsorDependencyResolver(container);
            configuration.DependencyResolver = dependencyResolver;

            return container;
        }    
    }

   


}