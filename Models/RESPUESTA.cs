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

    public partial class RESPUESTA
    {
        public int ID_RESPUESTA { get; set; }
        [Required]
        public string RESP { get; set; }
        public Nullable<int> C_LIKE { get; set; }
        public Nullable<int> C_DISLIKE { get; set; }
        public Nullable<bool> TIPO { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string USERNAME { get; set; }
        public Nullable<int> ID_PREGUNTA { get; set; }

        public virtual PREGUNTA PREGUNTA { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
