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
    
    public partial class expediente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public expediente()
        {
            this.paciente = new HashSet<paciente>();
            this.reporteCitas = new HashSet<reporteCitas>();
        }
    
        public long codigoExpediente { get; set; }
        public Nullable<long> codigoCitaProgramadasFK { get; set; }
    
        public virtual citasProgramadas citasProgramadas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<paciente> paciente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reporteCitas> reporteCitas { get; set; }
    }
}