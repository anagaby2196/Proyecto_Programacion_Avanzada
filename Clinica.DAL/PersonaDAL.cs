using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades.ETL;
using System.Threading.Tasks;



namespace Clinica.DAL
{
    public class PersonaDAL
    {
        public Boolean RegistrarUsuario(PersonaETL persona)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {
                    contexto.insertarPersona(persona.Nombre, persona.PrimerApellido, persona.SegundoApellido,
                    persona.Identificacion, persona.Telefono, persona.Correo, persona.TipoUsuario, persona.CodigoDireccion);
                    return true;
                }
                catch (Exception)
                {

                    throw;
                } 
            }
        }
        public Boolean AgregarUsuario(PersonaETL persona,UsuarioETL usuario)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try                {
                    var ultimaPersona = (from x in contexto.persona select x).LastOrDefault();

                    usuarios usr = new usuarios();
                    usr.codigoPersonaFK = ultimaPersona.codigoPersona;
                    usr.contrasena = usuario.Contrasena;

                    contexto.usuarios.Add(usr);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }                
            }                
        }
        public Boolean ActualizarPersona(PersonaETL persona)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                contexto.actualizaPersona(persona.Nombre,persona.PrimerApellido,persona.SegundoApellido,
                                            persona.Identificacion,persona.Telefono,persona.Correo,persona.TipoUsuario);
                return true;
            }
        }
    }
}
