using Clinica.DAL;
using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.BLL
{
    public class PacienteBLL
    {
        public Boolean RegristrarPacienteBLL(long CodigoPersona)
        {
            PacienteDAL prs = new PacienteDAL();
            return prs.RegristrarPaciente(CodigoPersona);
        }

        public paciente ConsultarPacienteBLL(string identificacion)
        {
            PacienteDAL prs = new PacienteDAL();
            return prs.ConsultarPaciente(identificacion);
        }

        public List<PersonaETL> ConsultarPacientesBLL()
        {
            PacienteDAL prs = new PacienteDAL();
            return prs.ConsultarPacientes();
        }

        public Boolean CambiarEstadoPacienteBLL(string identificacion)
        {
            PacienteDAL prs = new PacienteDAL();
            return prs.CambiarEstadoPaciente(identificacion);
        }


        public Boolean ActualizarDatosPacienteBLL(PacienteETL paciente)
        {
            PacienteDAL prs = new PacienteDAL();
            return prs.ActualizarDatosPaciente(paciente);
        }








    }
}
