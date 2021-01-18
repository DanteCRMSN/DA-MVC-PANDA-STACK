using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Net;
using System.Globalization;

using PANDA_MVC_V5.Models;

namespace PANDA_MVC_V5.Controllers
{
    public class RESPUESTAsController : Controller
    {
        private BD_PANDA_STACK_Entities db = new BD_PANDA_STACK_Entities();
        public ActionResult Index(int searching)
        {
            searching = 1;
            return View(db.RESPUESTA.Where(x => x.ID_PREGUNTA==searching).ToList());
        }
        /*
        public ActionResult Details(int searching)
        {
            return View();
        }
        */
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PREGUNTA/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PREGUNTA, CARRERA, TEMA, PREGUNTA1, RESUELTO, FECHA, NUM_RESP,USERNAME")] PREGUNTA pREGUNTA)
        {
            if (ModelState.IsValid)
            {
                pREGUNTA.RESUELTO = false;
                DateTime hoy = DateTime.Now;
                pREGUNTA.FECHA = hoy;
                pREGUNTA.NUM_RESP = 0;

                db.PREGUNTA.Add(pREGUNTA);
                db.SaveChanges();
                return RedirectToAction("Pregunta");
            }
            return View(pREGUNTA);
        }
    }
}