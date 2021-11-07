using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica.DAL;
using Entidades.ETL;


namespace Clinica.BLL
{
    public class PersonaBLL
    {

        public Boolean RegistrarUsuarioBLL(PersonaETL persona)
        {
            PersonaDAL prs = new PersonaDAL();
            return prs.RegistrarUsuario(persona);
        }
        public Boolean AgregarUsuarioBLL(PersonaETL persona, UsuarioETL usuario)
        {

            PersonaDAL prs = new PersonaDAL();
            return prs.AgregarUsuario(persona, usuario);
        }

        public Boolean ActualizarPersonaBLL(PersonaETL persona)
        {
            PersonaDAL prs = new PersonaDAL();
            return prs.ActualizarPersona(persona);
        }
    }
}
