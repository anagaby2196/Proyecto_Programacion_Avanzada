using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    class PersonaETL : DireccionETL
    {
        public long CodigoPersona { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Identificacion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int TipoUsuario { get; set; }
        public long CodigoDireccion { get; set; }
    }
}
