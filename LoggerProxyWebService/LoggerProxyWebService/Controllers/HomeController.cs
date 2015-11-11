using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using LoggerProxyWebService.ApiResults;

namespace LoggerProxyWebService.Controllers
{
    [System.Web.Http.RoutePrefix("api/Account")]
    [EnableCors(origins: "http://giftknackapi.azurewebsites.net", headers: "*", methods: "*")]
    public class HomeController : CustomApiController
    {
        public HomeController()
        {
            
        }

        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.Route("Register")]
        [System.Web.Http.HttpGet]
        public async Task<IHttpActionResult> Test()
        {
            return SuccessApiResult("test");
        }
    }
}
