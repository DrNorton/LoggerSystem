using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LoggerProxyWebService.Services;

namespace LoggerProxyWebService.DependencyInjection.Installers
{
    public class ServicesInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
           
                container.Register(
                    Component.For<IRabbitConnectionFactory, RabbitConnectionFactory>()
                        .DependsOn(Dependency.OnValue("hostName",
                             WebConfigurationManager.AppSettings["RabitIp"]))
                        .DependsOn(Dependency.OnValue("userName",
                         WebConfigurationManager.AppSettings["RabitUserName"]))
                        .DependsOn(Dependency.OnValue("password",
                           WebConfigurationManager.AppSettings["RabitPass"]))
                        .LifestyleTransient());
            

            
            container.Register(Component.For<IRabbitLogBus, RabbitLogBus>().LifestyleSingleton());
        }
    }
}
