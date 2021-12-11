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

        public Boolean IngresarCitaProgramada(string codigoDoctor, string pPadecimiento, string pTratamiento)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {

                    var ultimaCita = (from x in contexto.citas select x.codigoCitas).LastOrDefault();
                    //Ver de nuevo otra forma de sacar el valor del doctor en el html


                    citasProgramadas nuevaCita = new citasProgramadas();
                    nuevaCita.codigoCitasFK = ultimaCita;
                    //nuevaCita.codigoPacienteFK = 
                    //nuevaCita.estado = true;

                    //contexto.paciente.Add(nuevoPaciente);
                    //contexto.SaveChanges();
                    return true;


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<CitasProgramadasETL> ConsultarCitaProgramada(string codigoDoctor, string pPadecimiento, string pTratamiento)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                try
                {
                    var listaCPBD = (from x in contexto.citasProgramadas                                  
                                  where x.estado == true 
                                  select x).ToList();


                    List<CitasProgramadasETL> listaCP = new List<CitasProgramadasETL>();
                    if (listaCP.Count > 0)
                    {
                        foreach (var item in listaCP)
                        {
                            listaCP.Add(new CitasProgramadasETL
                            {
                                CodigoCita = item.CodigoCita,
                                CodigoPaciente = item.CodigoPaciente,
                                Padecimiento = pPadecimiento,
                                Tratamiento = pTratamiento
                            });
                        }
                    }


                }
                catch (Exception)
                {

                    throw;
                }

                return null;
            }
        }

    }
}
