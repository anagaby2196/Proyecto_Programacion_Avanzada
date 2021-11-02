using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    public class CitasProgramadasETL
    {
        public long CodigoCitasProgramadas { get; set; }
        public long CodigoCita { get; set; }
        public long CodigoPaciente { get; set; }
        public long CodigoDoctor { get; set; }
        public string Padecimiento { get; set; }
        public string Tratamiento { get; set; }
    }
}
