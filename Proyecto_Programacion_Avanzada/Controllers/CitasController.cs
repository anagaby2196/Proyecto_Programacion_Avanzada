using Clinica.DAL;
using Clinica_BLL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
            var nUsuario = (PersonaETL)Session["Usuario"];
            var nombreCompleto = nUsuario.Nombre + " " + nUsuario.PrimerApellido + " " + nUsuario.SegundoApellido;
            Session["nombreCompleto"] = nombreCompleto;
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
        public JsonResult SaveEvent(long codigoCitas, string asunto, string descripcion, DateTime horaInicio, DateTime horaFin, Boolean esTodoElDia, long codDoctor)
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
        public JsonResult SaveEventUsuario(long codigoCitas,string descripcion, DateTime horaInicio,DateTime horaFin,Boolean esTodoElDia,long codDoctor)
        {
            var nUsuario = (PersonaETL)Session["Usuario"];
            var nombreCompleto = nUsuario.Nombre + " " + nUsuario.PrimerApellido + " " + nUsuario.SegundoApellido;
            
            return SaveEvent(codigoCitas, nombreCompleto.ToUpper(), descripcion, horaInicio, horaFin, esTodoElDia, codDoctor);
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventoID, string Sujeto)
        {
            var status = false;
            var sujetoActivo = Session["nombreCompleto"];
            if (sujetoActivo.ToString().ToUpper() == Sujeto)
            {
                CitasBLL citas = new CitasBLL();
                status = citas.CancelarCitaBLL(eventoID);
                return new JsonResult { Data = new { status = status } };
            }

            return new JsonResult { Data = new { status = status } };
        }
    }



}