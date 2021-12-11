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

        public Boolean AgregarCitaProgramada(CitasProgramadasETL cpETL, string nombrePaciente)
        {

            CitasProgramadasDAL cp = new CitasProgramadasDAL();
            //cp.IngresarCitaProgramada();
            return true;
        }



        //var nombreCompleto = nUsuario.Nombre + " " + nUsuario.PrimerApellido + " " + nUsuario.SegundoApellido;





    }
}
