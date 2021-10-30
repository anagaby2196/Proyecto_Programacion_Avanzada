using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    class ReporteCitasETL : ExpedienteETL
    {
        public long CodigoRporteCita { get; set; }
        public long CodigoExpediente { get; set; }
    }
}
