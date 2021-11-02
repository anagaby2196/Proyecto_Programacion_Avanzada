using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    public class ExpedienteETL : CitasProgramadasETL
    {
        public long CodigoExpediente { get; set; }
        public long CodigoCitaProgramada { get; set; }
    }
}
