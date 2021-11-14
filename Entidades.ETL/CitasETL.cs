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
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string TemaColor { get; set; }
        public Boolean esTodoElDia { get; set; }
        public string Estado { get; set; }
    }
}

//asunto varchar(50),
//descripcion varchar(100),
//horaInicio datetime,
//horafin datetime,
//temaColor varchar(15),
//esTodoElDia bit,
//estado varchar(10)