using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_WebForm_Dapper_VB.NET_C_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => RedirectToAction("Index", "Customers");

    }
}
