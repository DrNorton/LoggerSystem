using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerProxyWebService.Dtos.Models
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        public int PlatformId { get; set; }
        
    }

    public class PlatformDto
    {
        public int Id { get; set; }
        public string PlatformName { get; set; }
      
    }
}
