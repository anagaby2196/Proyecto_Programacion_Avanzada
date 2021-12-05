using Clinica.BLL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada.Controllers
{
    public class PerfilController : Controller
    {
        // GET: Perfil
        
        public ActionResult Perfil()
        {
            var nUsuario = (PersonaETL)Session["Usuario"];
            
            ViewBag.Message = "Your application description page.";
            return View(nUsuario);
        }

        [HttpPost]
        public JsonResult ActualizarPerfil(string Nombre, string PrimerApellido,
            string SegundoApellido,string Telefono,string Correo,int Edad,char Sexo,string Provincia
            ,string Canton,string Distrito)
        {
            var status = false;
            var nUsuario = (PersonaETL)Session["Usuario"];
            if (nUsuario.Canton != null && nUsuario.Provincia != null && nUsuario.Distrito != null)
            {
                //actualizar
                PersonaBLL persona = new PersonaBLL();
                PersonaETL personaActualizar = new PersonaETL();
                personaActualizar.Nombre = Nombre;
                personaActualizar.PrimerApellido = PrimerApellido;
                personaActualizar.SegundoApellido = SegundoApellido;
                personaActualizar.Telefono = Telefono;
                personaActualizar.Correo = Correo;
                //personaActualizar.Edad = Edad;
                //personaActualizar.Sexo = Sexo;
                persona.ActualizarPersonaBLL(personaActualizar);
                
                status = persona.ActualizarDireccion(nUsuario.CodigoDireccion, Provincia, Canton, Distrito);
                Session["Usuario"] = persona.VerificarLogin(nUsuario.Correo, nUsuario.Contrasena);
            }
            else
            {
                //crearlo
            }


            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult Perfiles()
        {
            return View();
        }

    }
}