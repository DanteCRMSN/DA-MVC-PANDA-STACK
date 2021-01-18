using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PANDA_MVC_V5.Models;



namespace PANDA_MVC_V5.Controllers
{
    public class USUARIOsController : Controller
    {
        private BD_PANDA_STACK_Entities db = new BD_PANDA_STACK_Entities();
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                var check = db.USUARIO.FirstOrDefault(s => s.USERNAME == usuario.USERNAME);
                if (check == null)
                {
                    //usuario.PASSWORD = GetMD5(usuario.PASSWORD);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.USUARIO.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Ingreso()
        {
            ViewBag.Message = "Registro.";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ingreso(string username, string password)
        {
            if (ModelState.IsValid)
            {
                //var f_password = GetMD5(password);
                var data = db.USUARIO.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    //Session["FullName"] = data.FirstOrDefault().NOMBRE + " " + data.FirstOrDefault().APELLIDO;
                    Session["NOMBRE"] = data.FirstOrDefault().NOMBRE;
                    Session["USERNAME"] = data.FirstOrDefault().USERNAME;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Los datos ingresados son incorrectos.";
                    return View();
                    //return RedirectToAction("Index");
                }
            }
            return View();
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Ingreso", "USUARIOs");
        }


        /////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////

    }
}