//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class usuarios
    {
        public long codigoUsuario { get; set; }
        public string contrasena { get; set; }
        public Nullable<long> codigoPersonaFK { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<int> tipoUsuarioFK { get; set; }
    
        public virtual persona persona { get; set; }
        public virtual tipoUsuario tipoUsuario { get; set; }
    }
}
