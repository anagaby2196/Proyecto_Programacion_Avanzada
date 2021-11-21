using Entidades.ETL;
using Proyecto_Programacion_Avanzada.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada.Filtros
{
    public class VerificarFiltroSession : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var nUsuario = (PersonaETL)HttpContext.Current.Session["Usuario"];

            if (nUsuario == null && filterContext.Controller is HomeController == false)
            {
                
                if (filterContext.Controller is LoginController == false)
                {

                    filterContext.HttpContext.Response.Redirect("~/Login/Login");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Perfil/Perfil");
                }
            }

            base.OnActionExecuting(filterContext);
        }

    }
}