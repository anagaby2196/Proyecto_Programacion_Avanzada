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
            var nUsuario = (PersonaETL)Session["Usuario"];
            if (nUsuario.Canton != null && nUsuario.Provincia != null && nUsuario.Distrito != null)
            {
                //actualizar
                PersonaBLL persona = new PersonaBLL();
                persona.ActualizarDireccion(nUsuario.CodigoDireccion);
            }
            else
            {
                //crearlo
            }


            return new JsonResult { Data = new { status = status } };
        }
    }
}