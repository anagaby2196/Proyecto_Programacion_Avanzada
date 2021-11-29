using Clinica.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clinica.DAL;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using System.Text;
using System.Drawing;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class ReportesCitasController : Controller
    {
        // GET: ReportesCitas
        public ActionResult ReportesCitas()
        {
            
            return View();
        }

        //public ActionResult ChartFromEF()
        //{
        //    ReporteCitasBLL rp = new ReporteCitasBLL();
        //    rp.ConsultarReporteCitasBLL().ToArray();


        //    ClinicaMedicaV1Entities

        //    ReporteCitasDAL rp2 = new ReporteCitasDAL();
        //    rp2.ConsultarReporteCitas().ToList();
        //    var chart = new Chart();
        //    var area = new ChartArea();
        //    chart.ChartAreas.Add(area);
        //    var series = new Series();

        //    foreach (var item in rp)
        //    {
        //        series.Points.AddXY(item.)
        //    }


        //}
    }
}