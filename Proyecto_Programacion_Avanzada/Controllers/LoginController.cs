using Entidades.ETL;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        //POST:
        [HttpPost]
        public ActionResult Login(PersonaETL persona)
        {
            
            ViewBag.nombre = persona.Nombre;

            return View();
        }

    }
}