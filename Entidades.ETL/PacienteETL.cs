using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    class PacienteETL : PersonaETL
    {
        public long CodigoPaciente { get; set; }
        public long CodigoPersona { get; set; }
        public long CodigoCitaProgramada { get; set; }
        public long CodigoExpediente { get; set; }
    }
}
