using System;
using Newtonsoft.Json;

namespace LoggerProxyWebService.Dtos.Models
{
    public class LogModel
    {
        public string Guid { get; set; }
        public LogMessage Message { get; set; }
    }

    public class LogMessage
    {
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime Time { get; set; }
        public string Text { get; set; }
    }
}
