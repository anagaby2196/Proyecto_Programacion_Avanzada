using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    public class CitasETL
    {
        public long CodigoCitas { get; set; }
        public DateTime Dia { get; set; }
        public DateTime Hora { get; set; }
        public string Estado { get; set; }
    }
}
