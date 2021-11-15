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

        public Boolean RegristrarPaciente()
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {
                    var ultimaPersona = (from x in contexto.persona select x).LastOrDefault();
                    var ultimaCitaProgramada = (from x in contexto.citasProgramadas select x).LastOrDefault();
                    var ultimaExpediente = (from x in contexto.expediente select x).LastOrDefault();

                    paciente nuevoPaciente = new paciente();
                    nuevoPaciente.codigoPersonaFK = ultimaPersona.codigoPersona;
                    nuevoPaciente.codigoCitaProgramadaFK = ultimaCitaProgramada.codigoCitaProgramadas;
                    nuevoPaciente.codigoExpedienteFK = ultimaExpediente.codigoExpediente;
                    nuevoPaciente.estado = true;

                    contexto.paciente.Add(nuevoPaciente);
                    contexto.SaveChanges();

                }
                catch (Exception)
                {
                    throw;
                }
                return true;
            }
        }


        public List<PacienteETL> ConsultarPacientes()
        {

            List<PacienteETL> listaPacientes = new List<PacienteETL>();

            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var listaPacientesDB = (from x in contexto.paciente
                                       where x.estado == true
                                       select x).ToList();
                
                if (listaPacientesDB.Count > 0)
                {
                    foreach (var item in listaPacientesDB)
                    {
                        listaPacientes.Add(new PacienteETL
                        {
                          CodigoPaciente = item.codigoPaciente,
                          CodigoPersona = (long)item.codigoPersonaFK,
                          CodigoCitaProgramada = (long)item.codigoCitaProgramadaFK,
                          CodigoExpediente = (long)item.codigoExpedienteFK,
                          Estado = (bool)item.estado
                                                      
                        });
                    }
                }
                {
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
