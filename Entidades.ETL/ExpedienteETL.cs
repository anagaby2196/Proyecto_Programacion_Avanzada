using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    public class ExpedienteETL : PacienteETL 
    {
        public long CodigoExpediente { get; set; }
        public long CodigoCitaExpendiente { get; set; }

        public PersonaETL pETL { get; set; }

        public CitasProgramadasETL cpETL { get; set; }

        public DoctorETL doctorETL { get; set; }

        public CitasETL cETL { get; set; }    

        


    }
}
