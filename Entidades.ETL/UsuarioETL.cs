using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ETL
{
    public class UsuarioETL
    {
        public long CodigoUsuario { get; set; }
        public long CodigoPersona { get; set; }
        public string Contrasena { get; set; }
        public Boolean Estado { get; set; }
    }
}
