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
                        Estado = (bool)item.estado
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
                    Clinica.DAL.citas nuevaCita = new Clinica.DAL.citas();
                    nuevaCita.asunto = e.Asunto;
                    nuevaCita.descripsion = e.Descripcion;
                    nuevaCita.estado = true;
                    nuevaCita.horaInicio = e.HoraInicio;
                    nuevaCita.horafin = e.HoraFin;
                    nuevaCita.esTodoElDia = e.esTodoElDia;
                    nuevaCita.temaColor = e.TemaColor;

                    dc.citas.Add(nuevaCita);
                    dc.SaveChanges();
                }

                dc.SaveChanges();
                status = true;

            }
            return status;
        }

        public Boolean CancelarCita(int eventoID)
        {
            var status = false;
            using (var dc = new ClinicaMedicaV1Entities())
            {
                var v = dc.citas.Where(a => a.codigoCitas == eventoID).FirstOrDefault();
                if (v != null)
                {
                    v.estado = false;
                    v.temaColor = "Red";
                    dc.SaveChanges();
                    status = true;
                }

            }
            
            return status;
        }



    }
}
