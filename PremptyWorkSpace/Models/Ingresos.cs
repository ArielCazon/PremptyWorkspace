//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PremptyWorkSpace.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ingresos
    {
        public int IdIngresos { get; set; }
        public int IdUsuario { get; set; }
        public System.DateTime FechaActual { get; set; }
        public Nullable<System.DateTime> HoraIngreso { get; set; }
        public Nullable<System.DateTime> HoraEgreso { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}