using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class SondosController : Controller
    {
        // GET: Sondos
        public ActionResult Search(string name="Sondos")
        {
            var message = Server.HtmlEncode(name);
            return RedirectPermanent("http://www.twitter.com/SondosSamii");
        }

    }
}