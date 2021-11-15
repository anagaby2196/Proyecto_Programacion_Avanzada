using Entidades.ETL;
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
                var listaReporteCitasDB = (from x in contexto.reporteCitas                                        
                                        select x).ToList();
                
                if (listaReporteCitasDB.Count > 0)
                {
                    foreach (var item in listaReporteCitasDB)
                    {
                        listaReporteCitas.Add(new ReporteCitasETL
                        {
                            CodigoRporteCita = item.codigoreporteCitas,
                            CodigoExpediente = (long)item.codigoExpedienteFK                            

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
