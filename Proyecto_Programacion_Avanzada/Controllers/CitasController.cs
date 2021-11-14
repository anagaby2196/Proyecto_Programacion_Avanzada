using Clinica_BLL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class CitasController : Controller
    {
        // GET: Citas
        public ActionResult Index()
        {
            CitasBLL citas = new CitasBLL();
            var events = citas.CitasDisponiblesBLL().ToArray();
            return View();
        }

        [HttpGet]
        public JsonResult GetEvents()
        {
            CitasBLL citas = new CitasBLL();
            var events = citas.CitasDisponiblesBLL().ToArray();

            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

      

    }
}