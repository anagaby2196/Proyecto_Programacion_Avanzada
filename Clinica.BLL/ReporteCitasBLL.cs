using Clinica.DAL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.BLL
{
    public class ReporteCitasBLL
    {

        public List<ReporteCitasETL> ConsultarReporteCitasBLL()
        {
            ReporteCitasDAL rp = new ReporteCitasDAL();

            return rp.ConsultarReporteCitas().ToList();
        }
    }

}
