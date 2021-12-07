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
                        contexto.insertarPersona(persona.Nombre, persona.PrimerApellido, persona.SegundoApellido, persona.Identificacion, persona.Telefono, persona.Correo);

                        return true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            return false;

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

        public Boolean ActualizarDireccion(long codigoDireccion, string Provincia
            , string Canton, string Distrito)
        {
            try
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    var persona = (from x in contexto.direccion where x.codigoDireccion == codigoDireccion select x).FirstOrDefault();

                    if (persona != null)
                    {
                        persona.provincia = Provincia;
                        persona.canton = Canton;
                        persona.distrito = Distrito;
                        contexto.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public Boolean AgregarUsuario(PersonaETL persona)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {
                    var ultimaPersona = (from x in contexto.persona where x.identificacion == persona.Identificacion && x.correo == persona.Correo select x).FirstOrDefault();

                    usuarios usr = new usuarios();
                    usr.codigoPersonaFK = ultimaPersona.codigoPersona;
                    usr.contrasena = persona.Contrasena;
                    usr.tipoUsuarioFK = 1;
                    usr.estado = true;

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
        public Boolean ActualizarPersona(PersonaETL personaETL)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                //contexto.actualizaPersona(persona.Nombre, persona.PrimerApellido, persona.SegundoApellido,
                //                            persona.Identificacion, persona.Telefono, persona.Correo, persona.TipoUsuario);
                var persona = (from x in contexto.persona where x.identificacion == personaETL.Identificacion select x).FirstOrDefault();

                if (persona != null)
                {
                    persona.nombre = personaETL.Nombre;
                    persona.primerApellido = personaETL.PrimerApellido;
                    persona.segundoApellido = personaETL.SegundoApellido;
                    persona.telefono = personaETL.Telefono;
                    persona.SEXO = personaETL.Sexo.ToString();
                    persona.EDAD = personaETL.Edad;
                    contexto.SaveChanges();
                    return true;
                }

                return true;
            }
        }


        public PersonaETL VerificarUsuario(string correo, string contrasena)
        {
            try
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    var lista = (from x in contexto.usuarios
                                 join y in contexto.persona on x.codigoPersonaFK equals y.codigoPersona
                                 where x.contrasena == contrasena && y.correo == correo
                                 select new
                                 {
                                     CodigoPersona = y.codigoPersona,
                                     nombre = y.nombre,
                                     primerApellido = y.primerApellido,
                                     segundoApellido = y.segundoApellido,
                                     identificacion = y.identificacion,
                                     telefono = y.telefono,
                                     correo = y.correo,
                                     estado = x.estado,
                                     tipoUsuario = x.tipoUsuarioFK,
                                     sexo = y.SEXO,
                                     edad = y.EDAD
                                 });

                    var Direccion = (from x in contexto.usuarios
                                     join y in contexto.persona on x.codigoPersonaFK equals y.codigoPersona
                                     join d in contexto.direccion on y.codigoDireccionFK equals d.codigoDireccion
                                     where x.contrasena == contrasena && y.correo == correo
                                     select new
                                     {
                                         CodigoDireccion = y.codigoDireccionFK,
                                         tipoUsuario = x.tipoUsuarioFK,
                                         Canton = d.canton,
                                         Distrito = d.distrito,
                                         Provincia = d.provincia
                                     });

                    PersonaETL listaP = new PersonaETL();
                    if (lista.Count() > 0)
                    {
                        foreach (var item in lista)
                        {
                            listaP.CodigoPersona = item.CodigoPersona;
                            listaP.Nombre = item.nombre;
                            listaP.PrimerApellido = item.primerApellido;
                            listaP.SegundoApellido = item.segundoApellido;
                            listaP.Identificacion = item.identificacion;
                            listaP.Telefono = item.telefono;
                            listaP.Correo = item.correo;
                            listaP.TipoUsuario = (int)item.tipoUsuario;
                            listaP.Estado = (bool)item.estado;
                            listaP.Contrasena = contrasena;
                            if (item.edad == null || listaP.Sexo == null)
                            {
                                listaP.Edad = 0;
                                listaP.Sexo = 'N';
                            }
                            else
                            {
                                listaP.Edad = (int)item.edad;
                                listaP.Sexo = char.Parse(item.sexo);
                            }
                            
                        }

                        if (Direccion.Count() > 0)
                        {
                            foreach (var item in Direccion)
                            {
                                listaP.CodigoDireccion = (long)item.CodigoDireccion;
                                listaP.Canton = item.Canton;
                                listaP.Distrito = item.Distrito;
                                listaP.Provincia = item.Provincia;
                            }

                            
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
