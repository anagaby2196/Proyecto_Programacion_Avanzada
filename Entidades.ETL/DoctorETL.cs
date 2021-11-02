using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    public class DoctorETL : PersonaETL
    {
        public long CodigoDoctor { get; set; }
        public long CodigoPersona { get; set; }
    }
}
