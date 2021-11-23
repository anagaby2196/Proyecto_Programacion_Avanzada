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

        PersonaETL pETL { get; set; }  

        CitasProgramadasETL cpETL { get; set; } 

        DoctorETL doctorETL { get; set; } 
        
        CitasETL cETL { get; set; }    

        


    }
}
