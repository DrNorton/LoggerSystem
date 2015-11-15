using System.Collections.Generic;
using LoggerProxyWebService.Dtos.Models;

namespace LoggerProxyService.Ef.Repositories.Base
{
    public interface IDeviceRepository
    {
        long Registration(RegisterModel  register);
        List<DeviceDto> GetDevicesByPlatform(int platformId);
        List<PlatformDto> GetPlatforms();
    }
}