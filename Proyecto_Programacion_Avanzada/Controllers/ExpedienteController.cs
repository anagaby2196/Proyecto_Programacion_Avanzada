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
        public JsonResult ActualizaExpediente(string expediente)
        {
            var status = false;
            CitasProgramadasBLL cp = new CitasProgramadasBLL(); 
            

            return new JsonResult { Data = new { status = status } };
        }
    }

    


}