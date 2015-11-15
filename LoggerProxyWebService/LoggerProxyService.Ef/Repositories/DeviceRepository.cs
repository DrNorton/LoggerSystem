using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerProxyService.Ef.Repositories.Base;
using LoggerProxyWebService.Dtos.Models;

namespace LoggerProxyService.Ef.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly LoggerEfContext _context;

        public DeviceRepository(LoggerEfContext context)
        {
            _context = context;
        }

        public long Registration(RegisterModel  register)
        {
            var findedDevice=_context.Devices.FirstOrDefault(x => x.Guid.Equals(register.Guid));
            if (findedDevice == null)
            {
                var platform = _context.Platforms.FirstOrDefault(x => x.PlatformName == register.Platform);
                if (platform == null)
                {
                    throw new Exception("Операционная система, которую ты передал, не существует в базе");
                }
              
                //Устройство регистрируется впервые
                var newDevice = new Device() {Guid = register.Guid, Name = register.DeviceName, Platform = platform};
                _context.Devices.Add(newDevice);
                _context.SaveChanges();
                findedDevice = newDevice;
            }
            var projects = _context.Projects.ToList();
                var project = _context.Projects.FirstOrDefault(x => x.Name == register.ProjectName);
                if (project == null)
                {
                    throw new Exception("Имя проекта, которую ты передал, не существует в базе");
                }
                //Устройство уже было зарегано когда то. Надо добавить новую регистрацию
            var newRegistration = new Registration()
            {
                AssemblyVersion = register.Version,
                Device = findedDevice,
                Project = project,
                RegistrationTime = DateTime.Now
            };
            _context.Registrations.Add(newRegistration);
            _context.SaveChanges();
            return newRegistration.Id;
        }

        public List<DeviceDto> GetDevicesByPlatform(int platformId)
        {
           var devices=_context.Devices.Where(x=>x.PlatformId== platformId).ToList();
           return devices.Select(x => new DeviceDto() {Guid = x.Guid,Id = x.Id,Name = x.Name}).ToList();

        }

        public List<PlatformDto> GetPlatforms()
        {
            var platforms = _context.Platforms.Select(x=>new PlatformDto() {Id = x.Id,PlatformName = x.PlatformName}).ToList();
            return platforms;
        }
    }
}
