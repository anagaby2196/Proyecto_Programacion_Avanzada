using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    public class ReporteCitasETL : ExpedienteETL
    {
        public long CodigoRporteCita { get; set; }
        public long CodigoExpediente { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }        
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string padecimiento { get; set; }
        public string tratamiento { get; set; }
        public DateTime HoraInicio { get; set; }
        public string NombreDc { get; set; }
        public string PrimerApellidoDc { get; set; }
        public string SegundoApellidoDc { get; set; }




    }
}
