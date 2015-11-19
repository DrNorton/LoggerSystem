using System.Threading.Tasks;
using LoggerProxyWebService.Services;
using Microsoft.AspNet.SignalR;
using RabbitMQ.Client.Events;

namespace LoggerProxyWebService
{
    public class Chat:Hub
    {
        private readonly IRabbitLogBus _rabbitLogBus;

        private static int _id = 0;

        public Chat(IRabbitLogBus rabbitLogBus)
        {
            _rabbitLogBus = rabbitLogBus;
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            _rabbitLogBus.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public Task JoinGroup(string groupName)
        {
            _rabbitLogBus.Subscribe(groupName, Context.ConnectionId);
            return Groups.Add(Context.ConnectionId, groupName);
        }

        
    }
}
