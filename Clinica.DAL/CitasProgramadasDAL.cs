using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DAL
{
    public class CitasProgramadasDAL
    {

        public Boolean IngresarCitaProgramada(string codigoPaciente, long codigoDoctor)
        {
            long numeP = long.Parse(codigoPaciente);

            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {

                    var ultimaCita = (from x in contexto.citas orderby x.codigoCitas descending select x.codigoCitas).FirstOrDefault();
                    //Ver de nuevo otra forma de sacar el valor del doctor en el html


                    citasProgramadas nuevaCita = new citasProgramadas();
                    nuevaCita.codigoCitasFK = ultimaCita;
                    nuevaCita.codigoPacienteFK = numeP;
                    nuevaCita.codigoDoctorFK = codigoDoctor;
                    nuevaCita.estado = true;

                    contexto.citasProgramadas.Add(nuevaCita);
                    contexto.SaveChanges();
                    return true;


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public CitasProgramadasETL ConsultarCitaProgramada(long pCodigoPersona)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {
                    var codigoPaciente = (from x in contexto.paciente where x.codigoPersonaFK == pCodigoPersona
                                          select x).FirstOrDefault();


                    var citaProgramda = (from x in contexto.citasProgramadas
                                         join c in contexto.citas on x.codigoCitasFK equals c.codigoCitas
                                         where x.estado == true && x.codigoPacienteFK == codigoPaciente.codigoPaciente
                                         orderby x.codigoCitaProgramadas descending
                                         select new
                                         {
                                             codigoCitaProgramada = x.codigoCitaProgramadas,
                                             horaCita = c.horaInicio
                                         }).FirstOrDefault();
                    CitasProgramadasETL citasPETL = new CitasProgramadasETL();

                    citasPETL.CodigoCitasProgramadas = citaProgramda.codigoCitaProgramada;
                    citasPETL.HoraInicio = (DateTime)citaProgramda.horaCita;

                    return citasPETL;

                }
                catch (Exception)
                {
                    
                    throw;
                }
                

            }
        }

       

    }
}
