﻿using System.Web;
using System.Web.Mvc;

namespace Proyecto_Programacion_Avanzada
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filtros.VerificarFiltroSession());
        }
    }
}
