using Clinica.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class ReportesCitasController : Controller
    {
        // GET: ReportesCitas
        public ActionResult ReportesCitas()
        {
            ReporteCitasBLL rp = new ReporteCitasBLL();
            rp.ConsultarReporteCitasBLL(); 
            return View(rp);
        }
    }
}