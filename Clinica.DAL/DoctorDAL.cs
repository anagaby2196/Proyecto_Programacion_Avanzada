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
        public Boolean RegristrarDoctor(long codigoPersona)
        {
            
                try
                {
                    using (var contexto = new ClinicaMedicaV1Entities())
                    {
                    var existe = (from x in contexto.doctor where x.codigoPersonaFk == codigoPersona select x).FirstOrDefault();

                        if (existe!=null)
                        {
                        existe.estado = true;
                        contexto.SaveChanges();
                        return true;
                        }
                        else
                        {
                            doctor doc = new doctor();
                            doc.codigoPersonaFk = codigoPersona;
                            doc.estado = true;

                            contexto.doctor.Add(doc);
                            contexto.SaveChanges();
                            return true;
                        }
                        
                    }
                    
                }
                catch (Exception)
                {

                    throw;
                }
                
            
        }

        public List<PersonaETL> ConsultarDoctores()
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
                List<PersonaETL> listaDoctores = new List<PersonaETL>();

                if (listaDoctoresDB.Count > 0)
                {
                    foreach (var item in listaDoctoresDB)
                    {

                        listaDoctores.Add(new PersonaETL
                        {
                            Nombre = item.nombreCompleto,
                            codigoDoctor = item.codigoDoctor
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

                if (listaDoctoresDB != null)
                {
                    listaDoctoresDB.estado = false;
                    contexto.SaveChanges();
                    return true;
                }
                return false;


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
