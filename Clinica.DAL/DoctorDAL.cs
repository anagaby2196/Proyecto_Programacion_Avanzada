using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DAL
{
    public class DoctorDAL
    {
        public Boolean RegristrarDoctor(DoctorETL doctor)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {
                    var ultimaPersona = (from x in contexto.persona select x).LastOrDefault();


                    doctor doc = new doctor();
                    doc.codigoPersonaFk = ultimaPersona.codigoPersona;
                    doc.estado = true;

                    contexto.doctor.Add(doc);
                    contexto.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
                return true;
            }
        }

        public List<string> ConsultarDoctores()
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var listaDoctoresDB = (from x in contexto.doctor
                                       join y in contexto.persona on x.codigoPersonaFk equals y.codigoPersona
                                       where x.estado == true
                                       select new { 
                                       nombreCompleto = y.nombre + " " + y.primerApellido + " " + y.segundoApellido,
                                       codigoDoctor = x.codigoDoctor
                                       }).ToList();
                List<string> listaDoctores = new List<string>();

                if (listaDoctoresDB.Count > 0)
                {
                    foreach (var item in listaDoctoresDB)
                    {
                   
                        listaDoctores.AddRange( new string[]
                        {
                            item.nombreCompleto,
                            item.codigoDoctor.ToString()
                        });
                    }
                }
                               

                return listaDoctores;
            }

        }

        public doctor ConsultarDoctor(string identificacion)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                return (from x in contexto.doctor
                                       join y in contexto.persona on x.codigoPersonaFk equals y.codigoPersona
                                       where x.estado == true || y.identificacion == identificacion
                                       select x).FirstOrDefault();           
                                 
            }

        }

        public Boolean CambiarEstadoDoctor(string identificacion)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var listaDoctoresDB = (from x in contexto.doctor
                                       join y in contexto.persona on x.codigoPersonaFk equals y.codigoPersona
                                       where x.estado == true || y.identificacion == identificacion
                                       select x).FirstOrDefault();

                List<DoctorETL> listaDoctores = new List<DoctorETL>();
                if (listaDoctores.Count > 0)
                {
                    foreach (var item in listaDoctores) item.Estado = false;
                    contexto.SaveChanges();

                }
                return true;


            }

        }

        public Boolean ActualizarDatosDoctor(DoctorETL doctor)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var listaDoctorDB = (from x in contexto.doctor
                                        join y in contexto.persona on x.codigoPersonaFk equals y.codigoPersona
                                        where x.estado == true || y.identificacion == doctor.Identificacion
                                        select x).FirstOrDefault();

                List<PacienteETL> listaDoctor = new List<PacienteETL>();
                if (listaDoctor.Count > 0)
                {
                    foreach (var item in listaDoctor)
                    {
                        item.Nombre = doctor.Nombre;
                        item.PrimerApellido = doctor.PrimerApellido;
                        item.SegundoApellido = doctor.SegundoApellido;
                        item.Identificacion = doctor.Identificacion;
                        item.Telefono = doctor.Telefono;
                        item.Correo = doctor.Correo;
                    }
                    contexto.SaveChanges();

                }
                return true;
            }
        }
    }
}
