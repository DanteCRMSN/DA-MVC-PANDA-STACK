//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PANDA_MVC_V5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PREGUNTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PREGUNTA()
        {
            this.RESPUESTA = new HashSet<RESPUESTA>();
        }

        public int ID_PREGUNTA { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string CARRERA { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string TEMA { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string PREGUNTA1 { get; set; }
        public Nullable<bool> RESUELTO { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<System.DateTime> FECHA { get; set; }
        public Nullable<int> NUM_RESP { get; set; }
        public string USERNAME { get; set; }

        public virtual USUARIO USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RESPUESTA> RESPUESTA { get; set; }
    }
}
