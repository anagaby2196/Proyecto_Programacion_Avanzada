﻿using Entidades.ETL;
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

        public List<PersonaETL> VerificarLogin(string correo,string contrasena)
        {
            PersonaDAL prs = new PersonaDAL();
            return prs.VerificarUsuario(correo, contrasena);
        }



    }
}
