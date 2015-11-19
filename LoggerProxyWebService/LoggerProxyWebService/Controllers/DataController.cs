using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using LoggerProxyService.Ef.Repositories.Base;
using LoggerProxyWebService.ApiResults;
using LoggerProxyWebService.Dtos.Models;

namespace LoggerProxyWebService.Controllers
{
    [System.Web.Http.RoutePrefix("api/Data")]
    public class DataController : CustomApiController
    {
        private readonly IDeviceRepository _deviceRepository;

        public DataController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("GetDevicesByPlatform")]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> GetDevicesByPlatform(IdModel platformId)
        {
            return SuccessApiResult(_deviceRepository.GetDevicesByPlatform(platformId.Id).OrderByDescending(x=>x.LastUpdatedTime));
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("GetPlatforms")]
        [System.Web.Http.HttpPost]
        public async Task<IHttpActionResult> GetPlatforms()
        {
            return SuccessApiResult(_deviceRepository.GetPlatforms());
        }



    }
}
