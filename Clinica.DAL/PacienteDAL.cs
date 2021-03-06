using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DAL
{
    public class PacienteDAL
    {

        public Boolean RegristrarPaciente(long CodigoPersona)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {  
                    paciente nuevoPaciente = new paciente();
                    nuevoPaciente.codigoPersonaFK = CodigoPersona;
                    nuevoPaciente.estado = true;

                    contexto.paciente.Add(nuevoPaciente);
                    contexto.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
        }


        public List<PersonaETL> ConsultarPacientes()
        {

            List<PersonaETL> listaPacientes = new List<PersonaETL>();

            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var listaPacientesDB = (from x in contexto.paciente
                                        join y in contexto.persona on x.codigoPersonaFK equals y.codigoPersona
                                        join dc in contexto.usuarios on y.codigoPersona equals dc.codigoPersonaFK
                                        where x.estado == true & dc.tipoUsuarioFK == 1 select x).ToList();
                   
                if (listaPacientesDB.Count > 0)
                {
                    foreach (var item in listaPacientesDB)
                    {
                        listaPacientes.Add(new PersonaETL
                        {
                          Nombre = item.persona.nombre,
                          PrimerApellido = item.persona.primerApellido,                          
                          SegundoApellido = item.persona.segundoApellido,
                          Identificacion = item.persona.identificacion,
                          CodigoPersona = (long)item.codigoPersonaFK                            
                        });
                    }
                }
                return listaPacientes;
            }

        }

        public PersonaETL ConsultarPaciente(string identificacion)
        {


            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var personaDAL = (from  x in contexto.persona 
                                       where x.identificacion == identificacion & x.estado == true
                                       select x).FirstOrDefault();
                PersonaETL unaPersona = new PersonaETL();

                unaPersona.CodigoPersona = personaDAL.codigoPersona;
                unaPersona.Nombre = personaDAL.nombre;
                unaPersona.PrimerApellido = personaDAL.primerApellido;
                unaPersona.SegundoApellido = personaDAL.segundoApellido;
                unaPersona.Identificacion = personaDAL.identificacion;
                unaPersona.Telefono = personaDAL.telefono;                
                unaPersona.Correo = personaDAL.correo;
                unaPersona.Edad = (int)personaDAL.EDAD;
                if (personaDAL.SEXO == "F")
                {
                    unaPersona.Sexo = 'F';
                }
                else
                {
                    unaPersona.Sexo = 'M';
                }
                
                


                if (personaDAL.direccion != null)
                {   
                    unaPersona.Provincia = personaDAL.direccion.provincia;
                    unaPersona.Canton = personaDAL.direccion.canton;
                    unaPersona.Distrito = personaDAL.direccion.distrito;
                }
                else
                {
                    unaPersona.Provincia = "NO INDICA";
                    unaPersona.Canton = "NO INDICA";
                    unaPersona.Distrito = "NO INDICA";
                }
                
                return unaPersona;


            }

        }

        public Boolean CambiarEstadoPaciente(string identificacion)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var listaPacientesDB = (from x in contexto.paciente
                                       join y in contexto.persona on x.codigoPaciente equals y.codigoPersona
                                       where x.estado == true || y.identificacion == identificacion
                                       select x).FirstOrDefault();

                List<PacienteETL> listaPaciente = new List<PacienteETL>();
                if (listaPaciente.Count > 0)
                {
                    foreach (var item in listaPaciente) item.Estado = false;
                    contexto.SaveChanges();

                }

                return true;

            }

        }

        public Boolean ActualizarDatosPaciente(PacienteETL paciente)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var listaPacientesDB = (from x in contexto.paciente
                                        join y in contexto.persona on x.codigoPaciente equals y.codigoPersona
                                        where x.estado == true || y.identificacion == paciente.Identificacion
                                        select x).FirstOrDefault();

                List<PacienteETL> listaPaciente = new List<PacienteETL>();
                if (listaPaciente.Count > 0)
                {
                    foreach (var item in listaPaciente) {
                        item.Nombre = paciente.Nombre;
                        item.PrimerApellido = paciente.PrimerApellido;
                        item.SegundoApellido = paciente.SegundoApellido;
                        item.Identificacion = paciente.Identificacion;
                        item.Telefono = paciente.Telefono;
                        item.Correo = paciente.Correo;
                    }
                    contexto.SaveChanges();

                }
                return true;
            }
        }



    }
}
