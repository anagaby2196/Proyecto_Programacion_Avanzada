using Clinica.BLL;
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
        public ActionResult Registrar(string nombre, string papellido, string sapellido, string identificacion, string telefono, string correo, string contrasena)
        {
            PersonaETL persona = new PersonaETL();
            persona.Nombre = nombre;
            persona.PrimerApellido = papellido;
            persona.SegundoApellido = sapellido;
            persona.Identificacion = identificacion;
            persona.Telefono = telefono;
            persona.Correo = correo;
            persona.Contrasena = contrasena;

            PersonaBLL personabll = new PersonaBLL();
            if (personabll.RegistrarPersonaBLL(persona))
            {
                Login(persona.Correo,persona.Contrasena);
                return RedirectToAction("Index", "Citas");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string correoLogin,string contrasenaLogin)
        {
            PersonaBLL personabll = new PersonaBLL();
            var usuario = personabll.VerificarLogin(correoLogin, contrasenaLogin);
            Session["Usuario"] = usuario;
            return RedirectToAction("Index","Citas");
        }

    }
}