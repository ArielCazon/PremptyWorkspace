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
    
    public partial class Licencias
    {
        public int IdLicencia { get; set; }
        public int IdUsuario { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public Nullable<int> Motivo { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public bool Justificacion { get; set; } 
    
        public virtual MotivoLicencia MotivoLicencia { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
