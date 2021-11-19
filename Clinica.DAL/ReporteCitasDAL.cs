﻿using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DAL
{
    public class ReporteCitasDAL
    {
        public List<ReporteCitasETL> ConsultarReporteCitas()
        {
            List<ReporteCitasETL> listaReporteCitas = new List<ReporteCitasETL>();

            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var listaReporteCitasDB =(from x in contexto.reporteCitas
                 join e in contexto.expediente on x.codigoExpedienteFK equals e.codigoExpediente
                 join pt in contexto.paciente on e.codigoPacienteFK equals pt.codigoPaciente
                 join cp in contexto.citasProgramadas on pt.codigoCitaProgramadaFK equals cp.codigoCitaProgramadas
                 join c in contexto.citas on cp.codigoCitasFK equals c.codigoCitas
                 join p in contexto.persona on pt.codigoPersonaFK equals p.codigoPersona
                 join d in contexto.direccion on p.codigoDireccionFK equals d.codigoDireccion
                 join dc in contexto.doctor on cp.codigoDoctorFK equals dc.codigoDoctor
                 join pdc in contexto.persona on dc.codigoPersonaFk equals pdc.codigoPersona
                 select new { 
                 codigoRC = x.codigoreporteCitas,
                 codigoE = x.codigoExpedienteFK,
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
                
                if (listaReporteCitasDB.Count > 0)
                {
                    
                    foreach (var item in listaReporteCitasDB)
                    {
                        PersonaETL petl = new PersonaETL();

                        listaReporteCitas.Add(new ReporteCitasETL
                        {
                            CodigoRporteCita = item.codigoRC,
                            CodigoExpediente = (long)item.codigoE,
                            Nombre = item.nombre,
                            PrimerApellido = item.primerApellido,
                            SegundoApellido = item.segundoApellido,
                            Identificacion = item.identificacion,
                            Telefono = item.telefono,
                            Correo = item.correo,
                            Provincia = item.provincia,
                            Canton = item.canton,
                            Distrito = item.distrito,
                            padecimiento = item.padecimiento,
                            tratamiento = item.tratamiento,
                            HoraInicio = (DateTime)item.horaI,
                            NombreDc = item.nombre,
                            PrimerApellidoDc = item.primerApellido,
                            SegundoApellidoDc = item.segundoApellido


                        });
                    }
                }
                {
                }
                return listaReporteCitas;
            }

        }

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




    }
}
