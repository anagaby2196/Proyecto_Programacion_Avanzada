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
        public long CodigoCitaProgramada { get; set; }

        //Datos de Expediente
        public DateTime HoraInicio { get; set; }
        public string NombreDoctor { get; set; }
        public string Padecimiento { get; set; }
        public string Tratamiento { get; set; }


        public PersonaETL pETL { get; set; }

        public CitasProgramadasETL cpETL { get; set; }

        public DoctorETL doctorETL { get; set; }

        public CitasETL cETL { get; set; }    

        
    }
}
