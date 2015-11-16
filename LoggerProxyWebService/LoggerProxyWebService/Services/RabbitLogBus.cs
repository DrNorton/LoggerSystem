using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using RabbitMQ.Client.Events;

namespace LoggerProxyWebService.Services
{
    public interface IRabbitLogBus
    {
        void Subscribe(string guid,string connectedId);
        void Remove(string connectedId);
    }

    public class RabbitLogBus : IRabbitLogBus
    {
        private readonly IRabbitConnectionFactory _rabbitConnectionFactory;
        private List<ConnectedQueue> _list;

        public RabbitLogBus(IRabbitConnectionFactory rabbitConnectionFactory)
        {
            _rabbitConnectionFactory = rabbitConnectionFactory;
            _list=new List<ConnectedQueue>();
        }

        public void Subscribe(string guid, string connectedId)
        {
            var connection = _rabbitConnectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            
                channel.ExchangeDeclare(exchange: "topic_logs", type: "topic");
                var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: queueName,
                                      exchange: "topic_logs",
                                      routingKey: "*");


                var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<Chat>();
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body);
                context.Clients.Client(connectedId).sendMessage(message);
            };
                channel.BasicConsume(queue: queueName,
                                     noAck: true,
                                     consumer: consumer);
                _list.Add(new ConnectedQueue() { ConnectedId = connectedId, Consumer = consumer });

        }

        public void Remove(string connectedId)
        {
            var findedItem=_list.FirstOrDefault(x => x.ConnectedId == connectedId);
            if (findedItem != null)
            {
                _list.Remove(findedItem);
            }
        }

      
       
      
    }

    public class ConnectedQueue
    {
        public string ConnectedId { get; set; }
        public EventingBasicConsumer Consumer { get; set; }
    }
}
