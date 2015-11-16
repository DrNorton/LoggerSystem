using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LoggerProxyWebService.ApiResults;
using Microsoft.AspNet.SignalR;

namespace LoggerProxyWebService.DependencyInjection.Installers
{
    public class HubsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromAssemblyContaining<Chat>()
                    .BasedOn(typeof (Hub)).LifestyleTransient());
        }
    }
}
