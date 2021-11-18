﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clinica.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ClinicaMedicaV1Entities : DbContext
    {
        public ClinicaMedicaV1Entities()
            : base("name=ClinicaMedicaV1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<citas> citas { get; set; }
        public virtual DbSet<citasProgramadas> citasProgramadas { get; set; }
        public virtual DbSet<direccion> direccion { get; set; }
        public virtual DbSet<doctor> doctor { get; set; }
        public virtual DbSet<expediente> expediente { get; set; }
        public virtual DbSet<paciente> paciente { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<reporteCitas> reporteCitas { get; set; }
        public virtual DbSet<tipoUsuario> tipoUsuario { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
    
        public virtual int actualizaDireccion(Nullable<long> codigo, string provincia, string canton, string distrito, string resena)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(long));
    
            var provinciaParameter = provincia != null ?
                new ObjectParameter("provincia", provincia) :
                new ObjectParameter("provincia", typeof(string));
    
            var cantonParameter = canton != null ?
                new ObjectParameter("canton", canton) :
                new ObjectParameter("canton", typeof(string));
    
            var distritoParameter = distrito != null ?
                new ObjectParameter("distrito", distrito) :
                new ObjectParameter("distrito", typeof(string));
    
            var resenaParameter = resena != null ?
                new ObjectParameter("resena", resena) :
                new ObjectParameter("resena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("actualizaDireccion", codigoParameter, provinciaParameter, cantonParameter, distritoParameter, resenaParameter);
        }
    
        public virtual int actualizaPersona(string nombre, string primerApellido, string segundoApellido, string identificacion, string telefono, string correo, Nullable<int> tipoUsuarioFK)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("primerApellido", primerApellido) :
                new ObjectParameter("primerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("segundoApellido", segundoApellido) :
                new ObjectParameter("segundoApellido", typeof(string));
    
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var tipoUsuarioFKParameter = tipoUsuarioFK.HasValue ?
                new ObjectParameter("tipoUsuarioFK", tipoUsuarioFK) :
                new ObjectParameter("tipoUsuarioFK", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("actualizaPersona", nombreParameter, primerApellidoParameter, segundoApellidoParameter, identificacionParameter, telefonoParameter, correoParameter, tipoUsuarioFKParameter);
        }
    
        public virtual ObjectResult<consultarCita_Result> consultarCita(string estado)
        {
            var estadoParameter = estado != null ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarCita_Result>("consultarCita", estadoParameter);
        }
    
        public virtual ObjectResult<consultarDireccion_Result> consultarDireccion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarDireccion_Result>("consultarDireccion");
        }
    
        public virtual int consultarPersona(string identificacion)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("consultarPersona", identificacionParameter);
        }
    
        public virtual int consultarPersonas()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("consultarPersonas");
        }
    
        public virtual int eliminarDireccion(Nullable<long> codigo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("eliminarDireccion", codigoParameter);
        }
    
        public virtual int eliminarPersona(string identificacion)
        {
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("eliminarPersona", identificacionParameter);
        }
    
        public virtual int insertarDireccion(string provincia, string canton, string distrito, string resena)
        {
            var provinciaParameter = provincia != null ?
                new ObjectParameter("provincia", provincia) :
                new ObjectParameter("provincia", typeof(string));
    
            var cantonParameter = canton != null ?
                new ObjectParameter("canton", canton) :
                new ObjectParameter("canton", typeof(string));
    
            var distritoParameter = distrito != null ?
                new ObjectParameter("distrito", distrito) :
                new ObjectParameter("distrito", typeof(string));
    
            var resenaParameter = resena != null ?
                new ObjectParameter("resena", resena) :
                new ObjectParameter("resena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertarDireccion", provinciaParameter, cantonParameter, distritoParameter, resenaParameter);
        }
    
        public virtual int insertarPersona(string nombre, string pRIMERAPELLIDO, string segundoApellido, string identificacion, string telefono, string correo, Nullable<int> tipoUsuarioFK, Nullable<long> codigoDireccionFK)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var pRIMERAPELLIDOParameter = pRIMERAPELLIDO != null ?
                new ObjectParameter("PRIMERAPELLIDO", pRIMERAPELLIDO) :
                new ObjectParameter("PRIMERAPELLIDO", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("segundoApellido", segundoApellido) :
                new ObjectParameter("segundoApellido", typeof(string));
    
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("identificacion", identificacion) :
                new ObjectParameter("identificacion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(string));
    
            var correoParameter = correo != null ?
                new ObjectParameter("correo", correo) :
                new ObjectParameter("correo", typeof(string));
    
            var tipoUsuarioFKParameter = tipoUsuarioFK.HasValue ?
                new ObjectParameter("tipoUsuarioFK", tipoUsuarioFK) :
                new ObjectParameter("tipoUsuarioFK", typeof(int));
    
            var codigoDireccionFKParameter = codigoDireccionFK.HasValue ?
                new ObjectParameter("codigoDireccionFK", codigoDireccionFK) :
                new ObjectParameter("codigoDireccionFK", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertarPersona", nombreParameter, pRIMERAPELLIDOParameter, segundoApellidoParameter, identificacionParameter, telefonoParameter, correoParameter, tipoUsuarioFKParameter, codigoDireccionFKParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> ultimaInsercion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("ultimaInsercion");
        }
    
        public virtual ObjectResult<Nullable<long>> ultimaInsercionPersona()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("ultimaInsercionPersona");
        }
    }
}
