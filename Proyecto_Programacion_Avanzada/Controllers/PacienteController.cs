using Clinica.BLL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Paciente
        public ActionResult ConsultaPacientes()
        
        {
            PacienteBLL paciente = new PacienteBLL();
            paciente.ConsultarPacientesBLL();
            return View(paciente.ConsultarPacientesBLL());
        }

        public Boolean AgregarPaciente(long CodigoPersona)
        {

            PacienteBLL paciente = new PacienteBLL();
            return paciente.RegristrarPacienteBLL(CodigoPersona);
        }

        public ActionResult ConsultarPaciente(string identificacion)
        {
            PacienteBLL paciente = new PacienteBLL();
            var unPaciente = paciente.ConsultarPacienteBLL(identificacion);
            ExpedienteBLL expediente = new ExpedienteBLL();
            var exp = expediente.ConsultarExpediente(identificacion);
            
            if (unPaciente!=null)
                return Json(new { unPaciente, exp }, JsonRequestBehavior.AllowGet);
            else
                return Json(null, JsonRequestBehavior.DenyGet);
        }

        public ActionResult ConsultarDatosCitas(string identificacion)
        {
            PacienteBLL paciente = new PacienteBLL();
            var unPaciente = paciente.ConsultarPacienteBLL(identificacion);
            CitasProgramadasBLL verCitaProgramada = new CitasProgramadasBLL();
            var exp = verCitaProgramada.verCitaProgramada(unPaciente.CodigoPersona);

            if (unPaciente != null)
                return Json(new { unPaciente, exp }, JsonRequestBehavior.AllowGet);
            else
                return Json(null, JsonRequestBehavior.DenyGet);
        }

    }
}