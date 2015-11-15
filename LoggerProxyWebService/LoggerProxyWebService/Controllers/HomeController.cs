using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LoggerProxyWebService.Controllers
{
    public class HomeController: Controller
    {
        public HomeController()
        {
            Debug.WriteLine("dad");
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
