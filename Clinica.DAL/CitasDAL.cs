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
                var listaCitas = (from x in contexto.citas select x).ToList();

                List<CitasETL> ListaCitasETL = new List<CitasETL>();

                foreach (var item in listaCitas)
                {
                    ListaCitasETL.Add( new CitasETL
                    {
                        CodigoCitas = item.codigoCitas,
                        Asunto = item.asunto,
                        Descripcion = item.descripsion,
                        HoraInicio = (DateTime)item.horaInicio,
                        HoraFin = (DateTime)item.horafin,
                        TemaColor = item.temaColor,
                        esTodoElDia = (bool)item.esTodoElDia,
                        Estado = item.estado
                        //Asunto
                        //Descripcion
                        //HoraInicio
                        //horaFin
                        //tema
                        //EsTodoElDia
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
                    citaActual.horaInicio = Nuevacita.HoraInicio;
                    citaActual.horafin = Nuevacita.HoraFin;
                    citaActual.estado = Nuevacita.Estado;
                    citaActual.temaColor = Nuevacita.TemaColor;
                    citaActual.esTodoElDia = Nuevacita.esTodoElDia;
                    citaActual.descripsion = Nuevacita.Descripcion;
                    //citaActual.dia = Nuevacita.Dia;
                    //citaActual.estado = Nuevacita.Estado;
                    //citaActual.hora = Nuevacita.Hora;
                    //contexto.SaveChanges();
                    //return true;
                }

            }
                return false;
        }

        public Boolean SaveEvent(CitasETL e)
        {
            var status = false;
            using (var dc = new ClinicaMedicaV1Entities())
            {
                if (e.CodigoCitas > 0)
                {
                    //Update the event
                    var v = dc.citas.Where(a => a.codigoCitas == e.CodigoCitas).FirstOrDefault();
                    if (v != null)
                    {
                        v.asunto = e.Asunto;
                        v.horaInicio = e.HoraInicio;
                        v.horafin = e.HoraFin;
                        v.descripsion = e.Descripcion;
                        v.esTodoElDia = e.esTodoElDia;
                        v.temaColor = e.TemaColor;
                    }
                }
                else
                {
                    //dc.citas.Add();
                }

                dc.SaveChanges();
                status = true;

            }
            return true;
        }

    }
}
