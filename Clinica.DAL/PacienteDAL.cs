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
                          Identificacion = item.persona.identificacion
                                                      
                        });
                    }
                }
                return listaPacientes;
            }

        }

        public paciente ConsultarPaciente(string identificacion)
        {

            //List<PacienteETL> listaPacientes = new List<PacienteETL>();

            using (var contexto = new ClinicaMedicaV1Entities())
            {
                return (from x in contexto.paciente
                                        join y in contexto.persona on x.codigoPaciente equals y.codigoPersona
                                       where x.estado == true || y.identificacion == identificacion
                                       select x).FirstOrDefault();             
             
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
