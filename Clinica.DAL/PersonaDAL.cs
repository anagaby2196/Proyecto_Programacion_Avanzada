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

        public Boolean insertarDireccionPersona(PersonaETL personaETL)
        {
            try
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    var ultimaDireccion = (from x in contexto.direccion orderby x.codigoDireccion descending select x.codigoDireccion).FirstOrDefault();

                    var persona = (from x in contexto.persona where x.identificacion == personaETL.Identificacion select x).FirstOrDefault();

                    if (persona != null)
                    {
                        persona.nombre = personaETL.Nombre;
                        persona.primerApellido = personaETL.PrimerApellido;
                        persona.segundoApellido = personaETL.SegundoApellido;
                        persona.telefono = personaETL.Telefono;
                        persona.SEXO = personaETL.Sexo.ToString();
                        persona.EDAD = personaETL.Edad;
                        persona.codigoDireccionFK = ultimaDireccion;
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

        public Boolean AgregarDireccio(string provincia, string canton, string distrito)
        {
            try
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    direccion nuevaDireccion = new direccion();
                    nuevaDireccion.provincia = provincia;
                    nuevaDireccion.canton = canton;
                    nuevaDireccion.distrito = distrito;
                    contexto.direccion.Add(nuevaDireccion);
                    contexto.SaveChanges();
                    return true;
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
            try
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {

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
            catch (Exception)
            {

                throw;
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

        public List<PersonaETL> ConsultarPerfiles()
        {

            List<PersonaETL> listaPerfiles = new List<PersonaETL>();
            try
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    var listaPerfilesDB = (from x in contexto.paciente
                                           join y in contexto.persona on x.codigoPersonaFK equals y.codigoPersona
                                           join dc in contexto.usuarios on y.codigoPersona equals dc.codigoPersonaFK
                                           where x.estado == true
                                           select new
                                           {
                                               nombre = y.nombre,
                                               primerApellido = y.primerApellido,
                                               segundoApellido = y.segundoApellido,
                                               identificacion = y.identificacion,
                                               tipoUsuarioFK = dc.tipoUsuarioFK
                                           }).OrderBy(dc => dc.tipoUsuarioFK).ToList();

                    if (listaPerfilesDB.Count > 0)
                    {
                        foreach (var item in listaPerfilesDB)
                        {
                            listaPerfiles.Add(new PersonaETL
                            {
                                Nombre = item.nombre,
                                PrimerApellido = item.primerApellido,
                                SegundoApellido = item.segundoApellido,
                                Identificacion = item.identificacion,
                                TipoUsuario = (int)item.tipoUsuarioFK
                            });
                        }
                    }
                    return listaPerfiles;
                }
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        public List<string> NombrePaciente(string CodigoPersona)
        {
            long numeP = long.Parse(CodigoPersona);
            try
            {
                List<string> NombreYpaciente = new List<string>();


                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    var paciente = (from x in contexto.paciente
                                    join y in contexto.persona on x.codigoPersonaFK equals y.codigoPersona
                                    join dc in contexto.usuarios on y.codigoPersona equals dc.codigoPersonaFK
                                    where x.estado == true & dc.tipoUsuarioFK == 1 & x.codigoPersonaFK == numeP
                                    select new {
                                        nombre = y.nombre,
                                        primerApellido = y.primerApellido,
                                        segundoApellido = y.segundoApellido,
                                        identificacion = y.identificacion,
                                        tipoUsuarioFK = dc.tipoUsuarioFK,
                                        codigoPaciente = x.codigoPaciente
                                    }).FirstOrDefault();
                    string nombreCompleto = paciente.nombre + " " + paciente.primerApellido + " " + paciente.segundoApellido;
                    NombreYpaciente.AddRange( new string[]
                    {
                        nombreCompleto.ToUpper(),
                        paciente.codigoPaciente.ToString()
                    });
                    return NombreYpaciente;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Boolean CambiarTipoUsuario(int CodigoTipUsuario, string Identificacion)
        {
            try
            {
                DoctorDAL doctorinserta = new DoctorDAL();
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    var usuario = (from x in contexto.usuarios
                                   join y in contexto.persona on x.codigoPersonaFK equals y.codigoPersona where y.identificacion == Identificacion select x).FirstOrDefault();

                    if (usuario != null)
                    {
                        if (CodigoTipUsuario == 1)
                        {
                            
                            usuario.tipoUsuarioFK = CodigoTipUsuario;
                            contexto.SaveChanges();
                            return doctorinserta.CambiarEstadoDoctor(Identificacion);
                        }
                        else
                        {
                            usuario.tipoUsuarioFK = CodigoTipUsuario;
                            contexto.SaveChanges();
                            
                            doctorinserta.RegristrarDoctor(CodigoPersona(Identificacion));
                            return true;
                        }

                    }
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }



        public long CodigoPersona(string Identificacion)
        {
            try
            {
                using (var contexto = new ClinicaMedicaV1Entities())
                {
                    return (from x in contexto.persona
                                   where x.identificacion == Identificacion
                                   select x.codigoPersona).FirstOrDefault();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }



    }

}
