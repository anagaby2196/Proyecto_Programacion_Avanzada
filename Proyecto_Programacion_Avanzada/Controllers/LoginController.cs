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
            if (TempData["MensajeError"] != null)
            {
                ViewBag.Message = TempData["MensajeError"].ToString();
            }
            
            return View();
        }
        //POST:
        [HttpPost]
        public ActionResult Registrar(string nombre, string papellido, string sapellido, string identificacion, string telefono, string correo, string contrasena)
        {
            if (nombre.Length>2 && papellido.Length>2 && sapellido.Length>2 && 
                identificacion.Length<=12 && telefono.Length>6 && correo.Length>5 
                && contrasena.Length>=6)
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
                    PersonaBLL personabll2 = new PersonaBLL();
                    var usuario = personabll2.VerificarLogin(persona.Correo, persona.Contrasena);
                    Session["Usuario"] = usuario;
                    Session["TipoUsuario"] = usuario.TipoUsuario;
                    return RedirectToAction("Perfil", "Perfil");
                }
            }
            TempData["MensajeError"] = "Se ha digitado los datos incorrectamente";
            return RedirectToAction("Login",false);
        }

        [HttpPost]
        public ActionResult Login(string correoLogin,string contrasenaLogin)
        {
            if (correoLogin.Length > 6 && contrasenaLogin.Length >=6)
            {
                PersonaBLL personabll = new PersonaBLL();
                var usuario = personabll.VerificarLogin(correoLogin, contrasenaLogin);
                if (usuario != null)
                {
                    Session["Usuario"] = usuario;
                    Session["TipoUsuario"] = usuario.TipoUsuario;
                    return RedirectToAction("Perfil", "Perfil");
                }
            }

            TempData["MensajeError"] = "Usuario o contrasena invalida";
            return RedirectToAction("Login", false);
        }

        public ActionResult OlvidoContrasena()
        {
            return View();
        }


        public ActionResult CerrarSession()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}