using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica.DAL;
using Entidades.ETL;

namespace Clinica_BLL
{
    public class CitasBLL
    {
        public List<CitasETL> CitasDisponiblesBLL()
        {
            CitasDAL clinica = new CitasDAL();
            return clinica.CitasDisponibles();           
        }

        public Boolean ActualizarCitaBLL(CitasETL Nuevacita, int codigoCita)
        {
            CitasDAL clinica = new CitasDAL();
            return clinica.ActualizarCita(Nuevacita, codigoCita);
        }
    }
}
