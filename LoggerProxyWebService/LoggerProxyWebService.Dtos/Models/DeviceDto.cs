using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoggerProxyWebService.Dtos.Models
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? LastUpdatedTime { get; set; }
        
    }

    public class PlatformDto
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
      
    }
}
