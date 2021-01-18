using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PANDA_MVC_V5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult politicas_privacidad()
        {
            return View();
        }
        public ActionResult terminos_condiciones()
        {
            return View();
        }
    }
}