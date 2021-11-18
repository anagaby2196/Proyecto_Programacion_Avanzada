using Clinica.DAL;
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

        [HttpPost]
        public JsonResult SaveEvent(long codigoCitas,string asunto,string descripcion, DateTime horaInicio,DateTime horaFin,Boolean esTodoElDia)
        {
                        CitasETL evento = new CitasETL();
                        evento.CodigoCitas = codigoCitas;
                        evento.Asunto = asunto;
                        evento.Descripcion = descripcion;
                        evento.HoraInicio = (DateTime)horaInicio;
                        evento.HoraFin = (DateTime)horaFin;
                        evento.TemaColor = "Blue";
                        evento.esTodoElDia = (bool)esTodoElDia;

            var status = false;
            CitasBLL citas = new CitasBLL();
            if (evento != null)
            {
                status = citas.ActualizarCitaBLL(evento);
            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventoID)
        {
            CitasBLL citas = new CitasBLL();
            var status = citas.CancelarCitaBLL(eventoID);
            return new JsonResult { Data = new { status = status } };
        }
    }



}