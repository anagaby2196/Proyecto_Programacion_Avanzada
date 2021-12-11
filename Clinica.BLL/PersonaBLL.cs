using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica.DAL;


namespace Clinica.BLL
{
    public class PersonaBLL
    {

        public Boolean RegistrarPersonaBLL(PersonaETL persona)
        {
            PersonaDAL prs = new PersonaDAL();
            persona.TipoUsuario = 1;
            if (prs.RegistrarPersona(persona))
            {
                return AgregarUsuarioBLL(persona);
            }

            return false;
        }
        public Boolean AgregarUsuarioBLL(PersonaETL persona)
        {
            PersonaDAL prs = new PersonaDAL();
            return prs.AgregarUsuario(persona);
        }

        public Boolean ActualizarPersonaBLL(PersonaETL persona)
        {
            PersonaDAL prs = new PersonaDAL();
            return prs.ActualizarPersona(persona);
        }

        public PersonaETL VerificarLogin(string correo,string contrasena)
        {
            PersonaDAL prs = new PersonaDAL();
            return prs.VerificarUsuario(correo, contrasena);
        }

        public Boolean ActualizarDireccion(long codigoDireccion, string Provincia
            , string Canton, string Distrito)
        {
            PersonaDAL personaDAL = new PersonaDAL();
            return personaDAL.ActualizarDireccion(codigoDireccion, Provincia, Canton, Distrito);

        }

        public Boolean AgregarDireccion(string provincia, string canton, string distrito)
        {
            PersonaDAL personaDAL = new PersonaDAL();
            return personaDAL.AgregarDireccio(provincia, canton, distrito);
        }

        public Boolean insertarDireccionPersona(PersonaETL persona)
        {
            PersonaDAL personaDAL = new PersonaDAL();
            return personaDAL.insertarDireccionPersona(persona);
        }

        public List<PersonaETL> ConsultarPerfiles()
        {
            PersonaDAL personaDAL = new PersonaDAL();
            return personaDAL.ConsultarPerfiles();
        }

        public List<string> NombreCompleto(string CodigoPersona)
        {
            PersonaDAL personaDAL = new PersonaDAL();
            return personaDAL.NombrePaciente(CodigoPersona);
        }
    }
}
