using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace LoggerProxyWebService.Services
{
    public interface IRabbitConnectionFactory
    {
        IConnection CreateConnection();
    }

    public class RabbitConnectionFactory : IRabbitConnectionFactory
    {
        private ConnectionFactory _factory;

        public RabbitConnectionFactory(string hostName,string userName,string password)
        {
            _factory = new ConnectionFactory() { HostName = hostName, UserName = userName, Password = password };
        }
        public IConnection CreateConnection()
        {
            return _factory.CreateConnection();
        }
    }
}
