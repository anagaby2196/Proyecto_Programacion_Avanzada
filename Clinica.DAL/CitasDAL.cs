using Entidades.ETL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.DAL
{
    public class CitasDAL
    {
        public List<CitasETL> CitasDisponibles()
        {
            using(var contexto = new ClinicaMedicaV1Entities())
            {
                var listaCitas = contexto.consultarCita("AGENDADO").ToList();

                List<CitasETL> ListaCitasETL = new List<CitasETL>();

                foreach (var item in listaCitas)
                {
                    ListaCitasETL.Add( new CitasETL
                    {
                        CodigoCitas = item.codigoCitas,
                        Dia = (DateTime)item.dia,
                        Estado = item.estado,
                        Hora = (TimeSpan)item.hora
                    }
                        );
                }

                return ListaCitasETL;
            }
        }

        public Boolean ActualizarCita(CitasETL Nuevacita,int codigoCita)
        {
            using (var contexto = new ClinicaMedicaV1Entities())
            {
                var citaActual = (from x in contexto.citas where x.codigoCitas == codigoCita select x).FirstOrDefault();

                if (citaActual != null)
                {
                    citaActual.dia = Nuevacita.Dia;
                    citaActual.estado = Nuevacita.Estado;
                    citaActual.hora = Nuevacita.Hora;
                    contexto.SaveChanges();
                    return true;
                }

            }
                return false;
        }



    }
}
