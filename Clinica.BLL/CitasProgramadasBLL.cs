using Clinica.DAL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.BLL
{
    public class CitasProgramadasBLL
    {

        public Boolean AgregarCitaProgramada(string codigoPaciente, long codDoctor)
        {

            CitasProgramadasDAL cp = new CitasProgramadasDAL();
            
            return cp.IngresarCitaProgramada(codigoPaciente, codDoctor);
        }



    }
}
