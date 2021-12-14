using Clinica.BLL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class ExpedienteController : Controller
    {
        // GET: Expediente
        public ActionResult Index()
        {

            ExpedienteBLL exp = new ExpedienteBLL();
            exp.ConsultarExpedientes();
            return View();
        }

        [HttpPost]
        public JsonResult ActualizaExpediente(long CodigoCitaProgramadas,string padecimiento,string tratamiento)
        {
            var status = false;
            ExpedienteBLL cp = new ExpedienteBLL();
            cp.ActualizaCitaProgramadaBLL(CodigoCitaProgramadas, padecimiento, tratamiento);



            return new JsonResult { Data = new { status = status } };
        }
    }

    


}