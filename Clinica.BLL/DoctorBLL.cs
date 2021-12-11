using Clinica.DAL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.BLL
{
    public class DoctorBLL
    {
        public Boolean RegristrarPacienteBLL(DoctorETL doctor)
        {
            DoctorDAL dc = new DoctorDAL();
            return dc.RegristrarDoctor(doctor);
        }

        public List<string> ConsultarDoctoresBLL()
        {
            DoctorDAL dc = new DoctorDAL();
            return dc.ConsultarDoctores();
        }


        public doctor ConsultarDoctorBLL(string identificacion)
        {
            DoctorDAL dc = new DoctorDAL();
            return dc.ConsultarDoctor(identificacion);
        }

        public Boolean CambiarEstadoDoctorBLL(string identificacion)
        {
            DoctorDAL prs = new DoctorDAL();
            return prs.CambiarEstadoDoctor(identificacion);
        }

        public Boolean ActualizarDatosDoctorBLL(DoctorETL doctor)
        {
            DoctorDAL prs = new DoctorDAL();
            return prs.ActualizarDatosDoctor(doctor);
        }



    }
}
