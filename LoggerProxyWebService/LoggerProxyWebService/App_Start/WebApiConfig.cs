using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace LoggerProxyWebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IWindsorContainer container )
        {
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );

            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );



            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter());

            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SupportedEncodings.Add(Encoding.GetEncoding(1252));
            json.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            System.Web.Http.GlobalConfiguration.Configuration.Filters.Add(container.Resolve<IFilter>());


        }
    }

  
}
