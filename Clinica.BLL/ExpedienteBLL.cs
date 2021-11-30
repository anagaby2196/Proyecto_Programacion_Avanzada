﻿using Clinica.DAL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.BLL
{
    public class ExpedienteBLL
    {


        public List<ExpedienteETL> ConsultarExpedientes()
        {
            ExpedienteDAL expBLL = new ExpedienteDAL();
            return expBLL.ConsultarExpedientes();
        }

        public List<ExpedienteETL> ConsultarExpediente(string identificacion)
        {
            ExpedienteDAL expBLL = new ExpedienteDAL();
            return expBLL.ConsultarExpediente(identificacion);
        }
    }
}
