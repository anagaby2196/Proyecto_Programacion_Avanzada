using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DAL
{
    public class ExpedienteDAL
    {

        public Boolean RegristrarExpediente()
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {
                    var ultimoCP = (from x in contexto.citasProgramadas select x).LastOrDefault();


                    expediente exp = new expediente();
                    exp.codigoCitaProgramadasFK = ultimoCP.codigoCitaProgramadas;

                    contexto.expediente.Add(exp);
                    contexto.SaveChanges();

                    // registrar un reporte

                    ReporteCitasDAL rc = new ReporteCitasDAL();
                    rc.RegristrarReporteCita();

                }
                catch (Exception)
                {

                    throw;
                }
                return true;
            }
        }



        public List<ExpedienteETL> ConsultarExpediente(String Identificacion)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {

                    
                       var listaExpedientes = (from x in contexto.expediente                                
                                join cp in contexto.citasProgramadas on x.codigoCitaProgramadasFK equals cp.codigoCitaProgramadas
                                join c in contexto.citas on cp.codigoCitasFK equals c.codigoCitas
                                join p in contexto.persona on cp.codigoPacienteFK equals p.codigoPersona
                                join d in contexto.direccion on p.codigoDireccionFK equals d.codigoDireccion
                                join dc in contexto.doctor on cp.codigoDoctorFK equals dc.codigoDoctor
                                join pdc in contexto.persona on dc.codigoPersonaFk equals pdc.codigoPersona
                                where p.identificacion == Identificacion
                            select new
                            {
                                codigoExpediente = x.codigoExpediente,
                                codigoCitaProgramada = x.codigoCitaProgramadasFK,
                                nombre = p.nombre,
                                primerApellido = p.primerApellido,
                                segundoApellido = p.segundoApellido,
                                identificacion = p.identificacion,
                                telefono = p.telefono,
                                correo = p.correo,
                                provincia = d.provincia,
                                canton = d.canton,
                                distrito = d.distrito,
                                padecimiento = cp.padecimiento,
                                tratamiento = cp.tratamiento,
                                horaI = c.horaInicio,
                                nombreDc = pdc.nombre,
                                primerApellidoDc = pdc.primerApellido,
                                segundoApellidoDc = pdc.segundoApellido
                            }).ToList();



                    return null;
                }
                catch (Exception)
                {

                    throw;
                }
                return null;
            }
        }


        public List<ExpedienteETL> ConsultarExpedientes()
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {
                    List<ExpedienteETL> listaEexpedientes = new List<ExpedienteETL>();

                    var listaExpedientesDB = (from x in contexto.expediente
                            join cp in contexto.citasProgramadas on x.codigoCitaProgramadasFK equals cp.codigoCitaProgramadas
                            join p in contexto.persona on cp.codigoPacienteFK equals p.codigoPersona                            
                            join c in contexto.citas on cp.codigoCitasFK equals c.codigoCitas
                            join d in contexto.direccion on p.direccion.codigoDireccion equals d.codigoDireccion
                            join dc in contexto.doctor on cp.codigoDoctorFK equals dc.codigoDoctor
                            join pdc in contexto.persona on dc.codigoPersonaFk equals pdc.codigoPersona                            
                            select new
                            {
                                codigoExpediente = x.codigoExpediente,
                                CodigoCitaExpendiente = x.codigoExpediente,
                                nombre = p.nombre,
                                primerApellido = p.primerApellido,
                                segundoApellido = p.segundoApellido,
                                identificacion = p.identificacion,
                                telefono = p.telefono,
                                correo = p.correo,
                                provincia = d.provincia,
                                canton = d.canton,
                                distrito = d.distrito,
                                padecimiento = cp.padecimiento,
                                tratamiento = cp.tratamiento,
                                horaI = c.horaInicio,
                                nombreDc = pdc.nombre,
                                primerApellidoDc = pdc.primerApellido,
                                segundoApellidoDc = pdc.segundoApellido
                            }).ToList();

                    if(listaExpedientesDB.Count() > 0)
                    {
                        foreach( var item in listaExpedientesDB)
                        {
                            listaEexpedientes.Add(new ExpedienteETL
                            {
                                CodigoExpediente = item.codigoExpediente,
                                CodigoCitaExpendiente = (long)item.CodigoCitaExpendiente

                            });
                        }                         
                           
                    }
                    return listaEexpedientes;

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }
    }
}
