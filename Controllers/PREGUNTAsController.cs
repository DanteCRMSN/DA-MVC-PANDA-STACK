using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Globalization;

using System.Web.Mvc;

using PANDA_MVC_V5.Models;

namespace PANDA_MVC_V5.Controllers
{
    public class PREGUNTAsController : Controller
    {
        private BD_PANDA_STACK_Entities db = new BD_PANDA_STACK_Entities();
        public ActionResult Pregunta()
        {
            var pREGUNTA = db.PREGUNTA.OrderByDescending(p => p.FECHA);
            return View(pREGUNTA.ToList());
        }
        public ActionResult SinResp()
        {
            //var respuesta = db.RESPUESTA.Include(p => p.ID_PREGUNTA).Where().OrderByDescending(p => p.FECHA);
            var pREGUNTA = db.PREGUNTA.Where(d => d.NUM_RESP == 0).OrderByDescending(p => p.FECHA);
            return View(pREGUNTA.ToList());
        }
        public ActionResult Populares()
        {
            var pREGUNTA = db.PREGUNTA.OrderByDescending(p => p.NUM_RESP);
            return View(pREGUNTA.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTA pREGUNTA = db.PREGUNTA.Find(id);
            if (pREGUNTA == null)
            {
                return HttpNotFound();
            }

            return View(pREGUNTA);
        }

        // GET: PREGUNTA/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTA pREGUNTA = db.PREGUNTA.Find(id);
            if (pREGUNTA == null)
            {
                return HttpNotFound();
            }
            return View(pREGUNTA);
        }

        // POST: DEFAULT_PREGUNTAS_CONTROL/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PREGUNTA pREGUNTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pREGUNTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Pregunta");
            }
            return View(pREGUNTA);
        }

        // GET: PREGUNTA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PREGUNTA pregunta = db.PREGUNTA.Find(id);
            if (pregunta == null)
            {
                return HttpNotFound();
            }
            return View(pregunta);
        }

        // POST: PREGUNTA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PREGUNTA pREGUNTA = db.PREGUNTA.Find(id);
            db.PREGUNTA.Remove(pREGUNTA);
            db.SaveChanges();
            return RedirectToAction("Pregunta");
        }
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