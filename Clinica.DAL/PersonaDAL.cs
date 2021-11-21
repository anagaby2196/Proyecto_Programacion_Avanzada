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
        
        public Boolean RegistrarPersona(PersonaETL persona)
        {

            if (!VerificaPersona(persona))
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    try
                    {
                        contexto.insertarPersona(persona.Nombre, persona.PrimerApellido, persona.SegundoApellido, persona.Identificacion, persona.Telefono, persona.Correo, (int)persona.TipoUsuario);
                        //persona nuevaPersona = new persona();
                        //nuevaPersona.nombre = persona.Nombre;
                        //nuevaPersona.primerApellido = persona.PrimerApellido;
                        //nuevaPersona.segundoApellido = persona.SegundoApellido;
                        //nuevaPersona.identificacion = persona.Identificacion;
                        //nuevaPersona.telefono = persona.Telefono;
                        //nuevaPersona.correo = persona.Correo;
                        //nuevaPersona.tipoUsuarioFK = persona.TipoUsuario;

                        //contexto.persona.Add(nuevaPersona);
                        //contexto.SaveChanges();

                        return true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }return false;
            
        }

        public Boolean VerificaPersona(PersonaETL persona)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var existe = (from x in contexto.persona where x.identificacion == persona.Identificacion select x).FirstOrDefault();
                if (existe != null)
                {
                    return true;
                }
                return false;
            }
        }

        public Boolean AgregarUsuario(PersonaETL persona)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try{
                    var ultimaPersona = (from x in contexto.persona where x.identificacion == persona.Identificacion && x.correo == persona.Correo select x).FirstOrDefault();

                    usuarios usr = new usuarios();
                    usr.codigoPersonaFK = ultimaPersona.codigoPersona;
                    usr.contrasena = persona.Contrasena;

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


        public List<PersonaETL> VerificarUsuario(string correo, string contrasena)
        {
            try
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    var lista = (from x in contexto.usuarios join y in contexto.persona on x.codigoPersonaFK equals y.codigoPersona where x.contrasena == contrasena && y.correo == correo select y);

                    List<PersonaETL> listaP = new List<PersonaETL>();
                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            listaP.Add(new PersonaETL
                            {
                                Nombre = item.nombre,
                                PrimerApellido = item.primerApellido,
                                SegundoApellido = item.segundoApellido,
                                Identificacion = item.identificacion,
                                Telefono = item.telefono,
                                Correo = item.correo,
                                TipoUsuario = (int)item.tipoUsuarioFK,
                                Estado = (bool)item.estado
                            });
                        }

                        return listaP;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }


    }
}
