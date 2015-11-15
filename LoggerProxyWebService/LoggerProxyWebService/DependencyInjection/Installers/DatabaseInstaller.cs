using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LoggerProxyService.Ef;
using LoggerProxyService.Ef.Repositories;
using LoggerProxyService.Ef.Repositories.Base;


namespace LoggerProxyWebService.DependencyInjection.Installers
{
    public class DatabaseInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<LoggerEfContext, LoggerEfContext>().LifestyleTransient());
            container.Register(Component.For<IDeviceRepository, DeviceRepository>().LifestyleTransient());
        }
    }
}
