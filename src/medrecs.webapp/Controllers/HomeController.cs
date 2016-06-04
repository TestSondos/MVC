using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace medrecs.webapp.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("team")]
        public ActionResult Team()
        {
            return View();
        }

        [Route("why")]
        public ActionResult Why()
        {
            return View();
        }

        [Route("Download")]
        public ActionResult Download()
        {
            return View();
        }
    }
}