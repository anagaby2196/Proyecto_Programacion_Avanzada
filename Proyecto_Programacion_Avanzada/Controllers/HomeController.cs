using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult Citas()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Nosotros()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Servicios()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Promociones()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contacto()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}