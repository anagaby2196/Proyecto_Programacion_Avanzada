//------------------------------------------------------------------------------
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
