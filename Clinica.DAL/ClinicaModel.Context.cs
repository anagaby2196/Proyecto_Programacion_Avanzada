﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
        public virtual DbSet<dbo_persona> dbo_persona { get; set; }
    
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
    
        public virtual int consultar_trabajadores()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("consultar_trabajadores");
        }
    
        public virtual ObjectResult<consultarDireccion_Result> consultarDireccion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarDireccion_Result>("consultarDireccion");
        }
    
        public virtual int eliminarDireccion(Nullable<long> codigo)
        {
            var codigoParameter = codigo.HasValue ?
                new ObjectParameter("codigo", codigo) :
                new ObjectParameter("codigo", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("eliminarDireccion", codigoParameter);
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
    
        public virtual ObjectResult<Nullable<long>> ultimaInsercion()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("ultimaInsercion");
        }
    }
}
