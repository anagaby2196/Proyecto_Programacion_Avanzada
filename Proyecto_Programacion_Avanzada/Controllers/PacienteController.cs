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
            return View();
        }
    }
}