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
using Newtonsoft.Json;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class ReportesCitasController : Controller
    {
        // GET: ReportesCitas
        public ActionResult ReportesCitas()
        {
            DataFromDataBase();

            return View();
        }
        public ActionResult DataFromDataBase()
        {
            ReporteCitasBLL rp = new ReporteCitasBLL();
            var lista = rp.ContarCitasProgramadasBLL();

            try
            {
                
                ViewBag.DataPoints = JsonConvert.SerializeObject(lista.ToList(), _jsonSetting);

                return View(ViewBag.DataPoints);
            }
            catch (System.Data.Entity.Core.EntityException)
            {
                return View("Error");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return View("Error");
            }
        }
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
    }
}
