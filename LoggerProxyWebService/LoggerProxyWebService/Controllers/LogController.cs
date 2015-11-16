using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using LoggerProxyService.Ef.Repositories.Base;
using LoggerProxyWebService.ApiResults;
using LoggerProxyWebService.Dtos.Models;
using LoggerProxyWebService.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace LoggerProxyWebService.Controllers
{
    [System.Web.Http.RoutePrefix("api/Log")]
    [EnableCors(origins: "http://giftknackapi.azurewebsites.net", headers: "*", methods: "*")]
    public class LogController : CustomApiController
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IRabbitConnectionFactory _rabbitConnectionFactory;

        public LogController(IDeviceRepository deviceRepository,IRabbitConnectionFactory rabbitConnectionFactory)
        {
            _deviceRepository = deviceRepository;
            _rabbitConnectionFactory = rabbitConnectionFactory;
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Add")]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> AddToLog(LogModel log)
        {
            using (var connection = _rabbitConnectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "topic_logs",
                                    type: "topic");

                    var routingKey = log.Guid;
                    var message = JsonConvert.SerializeObject(log.Message);
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "topic_logs",
                                         routingKey: routingKey,
                                         basicProperties: null,
                                         body: body);
                    Console.WriteLine(" [x] Sent '{0}':'{1}'", routingKey, message);
                    

                }
            }
            return SuccessApiResult("test");
        }



        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Registration")]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> Registration(RegisterModel registration)
        {
           var registraionId= _deviceRepository.Registration(registration);
            return SuccessApiResult(registraionId);
        }
    }
}
